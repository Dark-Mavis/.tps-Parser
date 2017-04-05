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
        private List<string> file = new List<string>();
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
            string[] lines = directory.Split('\n');
            //it's lines.count-1 because the data split always adds a final line with nothing in it
            for (int i = 0; i < lines.Count() - 1; i++)
            {
                //getting rid of \r at the end of each string
                lines[i] = lines[i].Substring(0, (lines[i].Count() - 1));
                file.Add(lines[i]);
            }
        }
        private void createData(string directory)
        {
            readInFile(directory);
            location = 0;
            while (file[location].Substring(0,5)!="START")
            {
                location++;
            }
            while (!EOD)
            {
                addTruss();
            }
        }
        private void addTruss()
        {
            string TrussID = file[location].Substring(6);
            Truss newTrussToBeAdded = new Truss(TrussID);
            location++;
            while (file[location][0]=='#')
            {
                location++;
            }
            while (file[location].Substring(0, 5) != "START")
            {
                if (file[location][0] != '#')
                {
                    //use numberOfCoordinates to determine where the start of the next Truss is
                    int numberOfCoordinates=newTrussToBeAdded.AddComponent(file, location);
                    location = location + numberOfCoordinates + 1;
                }
                location++;
                if (file[location]=="EOD")
                {
                    EOD = true;
                    break;
                }
            }
            Trusses.Add(newTrussToBeAdded);
        }
    }
    class Truss
    {
        public List<Component> Components { get; set; }
        //creates an List of Polygon Objects based on the List of Coordinate sets
        public List<Polygon> Polygons
        {
            get
            {
                List<Polygon> newPolygons = new List<Polygon>();
                int pointer = 0;
                while (pointer<Components.Count())
                {
                    newPolygons.Add(new Polygon(Components[pointer].Coordinates, false));
                    pointer++;
                }
                return newPolygons;
            }
        }
        public string TrussID { get; set; }
        public Truss(string TrussID)
        {
            Components = new List<Component>();
            this.TrussID = TrussID;
        }
        public int AddComponent(List<string> data,int location)
        {
            ComponentID ID = enumComponentIDMaker(data[location][0]);
            int ComponentNumber = Convert.ToInt32(data[location].Substring(1,3));
            Component newComponent = new Component(ID, ComponentNumber);
            int pointer = 4;
            while (data[location][pointer]==' ')
            {
                pointer++;
            }
            //the number of Coordinates is told in the header for each truss
            int numberOfCoordinates = Convert.ToInt32(data[location].Substring(pointer,1));
            location++;
            for(int i = 0; i < numberOfCoordinates; i++)
            {
                double[] tokens = getXAndY(data[location + i]);
                newComponent.XY.Add(tokens);
            }
            Components.Add(newComponent);
            return numberOfCoordinates;
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
                List<Point> CoordinatesSet = new List<Point>();
                int pointer =0;
                while (pointer < XY.Count())
                {
                    CoordinatesSet.Add(new Point(new Inch(), XY[pointer][0], XY[pointer][1]));
                    pointer++;
                }
                return CoordinatesSet;
            }
            set
            {
                List<double[]> newCoordinates = new List<double[]>();
                int pointer = 0;
                while (pointer < value.Count())
                {
                    double[] currentCoordinate = new double[2];
                    currentCoordinate[0] = value[pointer].X.ValueInInches;
                    currentCoordinate[1] = value[pointer].Y.ValueInInches;
                    newCoordinates.Add(currentCoordinate);
                    pointer++;
                }
                this.XY = newCoordinates;
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
