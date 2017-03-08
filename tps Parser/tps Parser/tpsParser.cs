using GeometryClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitClassLibrary.DistanceUnit.DistanceTypes.Imperial.InchUnit;

namespace tps_Parser
{
    class tpsParser
    {
        private ArrayList file = new ArrayList();
        private string[] data;
        private int location;
        public List<Truss> Trusses { get; set; }
        private bool EOD = false;
        public tpsParser(string directory)
        {
            Trusses = new List<Truss>();
            createData(directory);
        }
        private void readInFile(string directory)
        {
            using (StreamReader sr = File.OpenText(directory))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    file.Add(s);
                }
            }
        }
        private void createData(string directory)
        {
            readInFile(directory);
            data = new string[file.Count];
            for (int i = 0; i < file.Count; i++)
            {
                data[i] = (string)file[i];
            }
            location = 0;
            while (data[location].Substring(0,5)!="START")
            {
                location++;
            }
            while (!EOD)
            {
                addTruss(data);
            }
        }
        private void addTruss(string[] data)
        {
            string TrussID = data[location].Substring(6);
            Truss cur = new Truss(TrussID);
            location++;
            while (data[location][0]=='#')
            {
                location++;
            }
            while (data[location].Substring(0, 5) != "START")
            {
                if (data[location][0] != '#')
                {
                    int counter=cur.AddComponent(data, location);
                    location = location + counter + 1;
                }
                location++;
                if (data[location]=="EOD")
                {
                    EOD = true;
                    break;
                }
            }
            Trusses.Add(cur);
        }
            static void Main(string[] args)
        {
            tpsParser fred = new tpsParser("C:/Users/Cerullium/OneDrive/Work/.tps Parser/3.tps");
        }
    }
    class Truss
    {
        public List<Component> Components { get; set; }
        public string TrussID { get; set; }
        public Truss(string TrussID)
        {
            Components = new List<Component>();
            this.TrussID = TrussID;
        }
        public int AddComponent(string[] data,int location)
        {
            ComponentID ID = enumComponentIDMaker(data[location][0]);
            int ComponentNumber = Convert.ToInt32(data[location].Substring(1,3));
            Component cur = new Component(ID, ComponentNumber);
            int pointer = 4;
            while (data[location][pointer]==' ')
            {
                pointer++;
            }
            int counter = Convert.ToInt32(data[location].Substring(pointer,1));
            location++;
            for(int i = 0; i < counter; i++)
            {
                double[] tokens = getXAndY(data[location + i]);
                cur.XY.Add(tokens);
            }
            Components.Add(cur);
            return counter;
        }
        private double[] getXAndY(string data)
        {
            string[] tokens = data.Split(',');
            double[] XY = new double[2];
            XY[0] = Convert.ToDouble(tokens[0]);
            XY[1] = Convert.ToDouble(tokens[1]);
            return XY;
        }
        private ComponentID enumComponentIDMaker(char data)
        {
            if (data == 'T')
            {
                return ComponentID.TopChord;
            }
            else if (data == 'B')
            {
                return ComponentID.BottomChord;
            }
            else if (data == 'W')
            {
                return ComponentID.Web;
            }
            else if (data == 'P')
            {
                return ComponentID.Plate;
            }
            else
            {
                return ComponentID.Other;
            }
        }
    }
    public enum ComponentID
    {
        TopChord,
        BottomChord,
        Web,
        Plate,
        Other
    }
    class Component
    {
        public ComponentID ID { get; set; }
        public int ComponentNumber { get; set; }
        public List<Point> Coordinates
        {
            get
            {
                List<Point> cur = new List<Point>();
                int pointer =0;
                while (pointer < XY.Count())
                {
                    cur.Add(new Point(new Inch(), XY[pointer][0], XY[pointer][1]));
                    pointer++;
                }
                return cur;
            }
            set
            {
                List<double[]> cur = new List<double[]>();
                int pointer = 0;
                while (pointer < value.Count())
                {
                    double[] curcur = new double[2];
                    curcur[0] = value[pointer].X.ValueInInches;
                    curcur[1] = value[pointer].Y.ValueInInches;
                    cur.Add(curcur);
                    pointer++;
                }
                this.XY = cur;
            }
        }
        public List<double[]> XY { get; set; }
        public Component(ComponentID ID,int ComponentNumber)
        {
            XY = new List<double[]>();
            this.ComponentNumber = ComponentNumber;
            this.ID = ID;
        }
    }
}
