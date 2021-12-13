using System;
using System.Collections.Generic;
namespace baithi
{
    public class Graph
    {
        private const int max_verts = 20;
        int infinity = 1000000;
        Vertex[] vertexList;
        int[,] adjMat;
        int nVerts;
        int nTree;
        DistOriginal[] sPath;
        int currentVert;
        int startToCurrent;

        public Graph()
        {
            vertexList = new Vertex[max_verts];
            adjMat = new int[max_verts, max_verts];
            nVerts = 0; nTree = 0;
            for (int j = 0; j <= max_verts - 1; j++)
                for (int k = 0; k <= max_verts - 1; k++)
                    adjMat[j, k] = infinity;
            sPath = new DistOriginal[max_verts];
        }
        public void AddVertex(Map lab)
        {
            vertexList[nVerts] = new Vertex(lab);
            nVerts++;
        }
        public void AddEdge(int start, int theEnd, int weight)
        {
            adjMat[start, theEnd] = weight;
        }
        public int GetMin()
        {
            int minDist = infinity;
            int indexMin = 0;
            for (int j = 1; j <= nVerts - 1; j++)
                if (!(vertexList[j].isInTree) && sPath[j].distance < minDist)
                {
                    minDist = sPath[j].distance; indexMin = j;
                }
            return indexMin;
        }
        public void AdjustShortPath()
        {
            int column = 1;
            while (column < nVerts)
                if (vertexList[column].isInTree) column++;
                else
                {
                    int currentToFring = adjMat[currentVert, column];
                    int startToFringe = startToCurrent + currentToFring;
                    int sPathDist = sPath[column].distance;
                    if (startToFringe < sPathDist)
                    {
                        sPath[column].parentVert = currentVert;
                        sPath[column].distance = startToFringe;
                    }
                    column++;
                }
        }
        public string GetPosName(int pos)
        {
            switch (pos)
            {
                case 0:
                    return "Bệnh viện Đại học Y dược";
                case 1:
                    return "Đại học kinh tế TP.HCM CSB";
                case 2:
                    return "Chợ Bến Thành";
                case 3:
                    return "Bệnh viện Hùng Vương";
                case 4:
                    return "Trường THPT Mạc Đĩnh Chi";
                case 5:
                    return "Trung tâm mua sắm AEON Mall Bình Tân";
                case 6:
                    return "Đại học Khoa học tự nhiên TPHCM";
                case 7:
                    return "Đài truyền hình HTV";
                default:
                    return "";
            }
        }
        public void Path(int n)
        {
            int startTree = 0;
            vertexList[startTree].isInTree = true;
            nTree = 1;
            for (int j = 0; j <= nVerts; j++)
            {
                int tempDist = adjMat[startTree, j];
                sPath[j] = new DistOriginal(startTree, tempDist);
            }
            while (nTree < nVerts)
            {
                int indexMin = GetMin();
                int minDist = sPath[indexMin].distance;
                currentVert = indexMin;
                startToCurrent = sPath[indexMin].distance;
                vertexList[currentVert].isInTree = true;
                nTree++;
                AdjustShortPath();
            }

            //In thông tin
            System.Console.WriteLine("Những thông tin hữu ích về địa điểm bạn chọn để đi đến: ");
            System.Console.WriteLine("Quãng đường ngắn nhất từ Bệnh viện Đại học Y dược đến {0} là: {1}", GetPosName(n), sPath[n].distance);
            System.Console.WriteLine("Tuyến đường ngắn nhất phải đi là: ");
            PrintPath(0, n, sPath);
            DisplayNearestPos(n, adjMat);
            DisplayCost(n);

            nTree = 0;
            for (int j = 0; j <= nVerts - 1; j++)
                vertexList[j].isInTree = false;
        }
        public void DisplayCost(int n)
        {
            System.Console.WriteLine("\nCác loại phương tiện: ");
            System.Console.WriteLine("Xe buýt: Phím 1");
            System.Console.WriteLine("Xe taxi: Phím 2");
            System.Console.WriteLine("Xe máy: Phím 3");

        Error:
            System.Console.Write("Nhập lựa chọn của bạn: ");
            int numberChoose = Int32.Parse(Console.ReadLine());
            BusPath(n);
            System.Console.WriteLine();
            switch (numberChoose)
            {
                case 1:
                    List<Bus> listBus = new List<Bus>();
                    Bus choLon = new Bus("01020", "Bến xe Chợ Lớn", 30f, 500f);
                    listBus.Add(choLon);
                    Bus quan8 = new Bus("03428", "Bến xe Quận 8", 40f, 1000f);
                    listBus.Add(quan8);
                    Bus benThanh = new Bus("02420", "Bến xe Bến Thành", 35f, 800f);
                    listBus.Add(benThanh);
                    System.Console.WriteLine("**********CÁC TUYẾN XE BUÝT********");
                    System.Console.WriteLine("Bến xe Chợ Lớn: Phím 0");
                    System.Console.WriteLine("Bến xe Quận 8: Phím 1");
                    System.Console.WriteLine("Bến xe Bến Thành: Phím 2");

                Error1:
                    System.Console.Write("Nhập lựa chọn của bạn: ");
                    int busChoose = Int32.Parse(Console.ReadLine());
                    switch (busChoose)
                    {
                        case 0:
                            float choLonCost = sPath[n].distance * listBus[busChoose].getPrice();
                            double choLonTime = Math.Round((sPath[n].distance / listBus[busChoose].getSpeed()) * 60);
                            System.Console.WriteLine("Tiền đi xe buýt của hãng " + listBus[busChoose].getName() + " là: " + choLonCost + "đ");
                            System.Console.WriteLine("Thời gian đi xe buýt của hãng " + listBus[busChoose].getName() + " là: " + choLonTime + " phút");
                            break;
                        case 1:
                            float quan8Cost = sPath[n].distance * listBus[busChoose].getPrice();
                            double quan8Time = Math.Round((sPath[n].distance / listBus[busChoose].getSpeed()) * 60);
                            System.Console.WriteLine("Tiền đi xe buýt của hãng " + listBus[busChoose].getName() + " là: " + quan8Cost + "đ");
                            System.Console.WriteLine("Thời gian đi xe buýt của hãng " + listBus[busChoose].getName() + " là: " + quan8Time + " phút");
                            break;
                        case 2:
                            float benThanhCost = sPath[n].distance * listBus[busChoose].getPrice();
                            double benThanhTime = Math.Round((sPath[n].distance / listBus[busChoose].getSpeed()) * 60);
                            System.Console.WriteLine("Tiền đi xe buýt của hãng " + listBus[busChoose].getName() + " là: " + benThanhCost + "đ");
                            System.Console.WriteLine("Thời gian đi xe buýt của hãng " + listBus[busChoose].getName() + " là: " + benThanhTime + " phút");
                            break;
                        default:
                            System.Console.WriteLine("Yêu cầu bạn nhập không đúng vui lòng nhập lại! (0 - 2)");
                            goto Error1;
                    }
                    break;
                case 2:
                    List<Car> listCar = new List<Car>();
                    Car grabCar = new Car("13203", "Taxi Grab", 45f, 5000f);
                    listCar.Add(grabCar);
                    Car uberCar = new Car("12131", "Taxi Uber", 42f, 4800f);
                    listCar.Add(uberCar);
                    Car maiLinhCar = new Car("14205", "Taxi Mai Linh", 50f, 5500f);
                    listCar.Add(maiLinhCar);
                    System.Console.WriteLine("**********CÁC HÃNG XE TAXI CÔNG NGHỆ********");
                    System.Console.WriteLine("Grab: Phím 0");
                    System.Console.WriteLine("Uber: Phím 1");
                    System.Console.WriteLine("Taxi Mai Linh: Phím 2");

                Error2:
                    System.Console.Write("Nhập lựa chọn của bạn: ");
                    int carChoose = Int32.Parse(Console.ReadLine());
                    switch (carChoose)
                    {
                        case 0:
                            float grabCarCost = sPath[n].distance * listCar[carChoose].getPrice();
                            double grabCarTime = Math.Round((sPath[n].distance / listCar[carChoose].getSpeed()) * 60);
                            System.Console.WriteLine("Tiền đi xe hơi của hãng " + listCar[carChoose].getName() + " là: " + grabCarCost + "đ");
                            System.Console.WriteLine("Thời gian đi xe hơi của hãng " + listCar[carChoose].getName() + " là: " + grabCarTime + " phút");
                            break;
                        case 1:
                            float uberCarCost = sPath[n].distance * listCar[carChoose].getPrice();
                            double uberCarTime = Math.Round((sPath[n].distance / listCar[carChoose].getSpeed()) * 60);
                            System.Console.WriteLine("Tiền đi xe hơi của hãng " + listCar[carChoose].getName() + " là: " + uberCarCost + "đ");
                            System.Console.WriteLine("Thời gian đi xe hơi của hãng " + listCar[carChoose].getName() + " là: " + uberCarTime + " phút");
                            break;
                        case 2:
                            float maiLinhCarCost = sPath[n].distance * listCar[carChoose].getPrice();
                            double maiLinhCarTime = Math.Round((sPath[n].distance / listCar[carChoose].getSpeed()) * 60);
                            System.Console.WriteLine("Tiền đi xe hơi của hãng " + listCar[carChoose].getName() + " là: " + maiLinhCarCost + "đ");
                            System.Console.WriteLine("Thời gian đi xe hơi của hãng " + listCar[carChoose].getName() + " là: " + maiLinhCarTime + " phút");
                            break;
                        default:
                            System.Console.WriteLine("Yêu cầu bạn nhập không đúng vui lòng nhập lại! (0 - 2)");
                            goto Error2;
                    }
                    break;
                case 3:
                    List<Motorbike> listMotorbike = new List<Motorbike>();
                    Motorbike grabMotorbike = new Motorbike("21023", "Xe máy Grab", 30f, 2500f);
                    listMotorbike.Add(grabMotorbike);
                    Motorbike uberMotorbike = new Motorbike("25037", "Xe máy Uber", 32f, 2600f);
                    listMotorbike.Add(uberMotorbike);
                    Motorbike beMotorBike = new Motorbike("24306", "Xe máy BE", 29f, 2400f);
                    listMotorbike.Add(beMotorBike);
                    System.Console.WriteLine("********CÁC HÃNG XE MÁY CÔNG NGHỆ*******");
                    System.Console.WriteLine("Grab: Phím 0");
                    System.Console.WriteLine("Uber: Phím 1");
                    System.Console.WriteLine("BE: Phím 2");

                Error3:
                    System.Console.Write("Nhập lựa chọn của bạn: ");
                    int motorBikeChoose = Int32.Parse(Console.ReadLine());
                    switch (motorBikeChoose)
                    {
                        case 0:
                            float grabMotorbikeCost = sPath[n].distance * listMotorbike[motorBikeChoose].getPrice();
                            double grabMotorbikeTime = Math.Round((sPath[n].distance / listMotorbike[motorBikeChoose].getSpeed()) * 60);
                            System.Console.WriteLine("Tiền đi xe máy của hãng " + listMotorbike[motorBikeChoose].getName() + " là: " + grabMotorbikeCost + "đ");
                            System.Console.WriteLine("Thời gian đi xe hơi của hãng " + listMotorbike[motorBikeChoose].getName() + " là: " + grabMotorbikeTime + " phút");
                            break;
                        case 1:
                            float uberMotorbikeCost = sPath[n].distance * listMotorbike[motorBikeChoose].getPrice();
                            double uberMotorbikeTime = Math.Round((sPath[n].distance / listMotorbike[motorBikeChoose].getSpeed()) * 60);
                            System.Console.WriteLine("Tiền đi xe máy của hãng " + listMotorbike[motorBikeChoose].getName() + " là: " + uberMotorbikeCost + "đ");
                            System.Console.WriteLine("Thời gian đi xe hơi của hãng " + listMotorbike[motorBikeChoose].getName() + " là: " + uberMotorbikeTime + " phút");
                            break;
                        case 2:
                            float beMotorbikeCost = sPath[n].distance * listMotorbike[motorBikeChoose].getPrice();
                            double beMotorbikeTime = Math.Round((sPath[n].distance / listMotorbike[motorBikeChoose].getSpeed()) * 60);
                            System.Console.WriteLine("Tiền đi xe máy của hãng " + listMotorbike[motorBikeChoose].getName() + " là: " + beMotorbikeCost + "đ");
                            System.Console.WriteLine("Thời gian đi xe hơi của hãng " + listMotorbike[motorBikeChoose].getName() + " là: " + beMotorbikeTime + " phút");
                            break;
                        default:
                            System.Console.WriteLine("Yêu cầu bạn nhập không đúng vui lòng nhập lại! (0 - 2)");
                            goto Error3;
                    }
                    break;
                default:
                    System.Console.WriteLine("Yêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 3)");
                    goto Error;
            }

        }
        public void PrintPath(int start, int finish, DistOriginal[] back)
        {
            if (start == finish)
            {
                System.Console.Write("Bệnh viện Đại học Y dược");
            }
            else
            {
                PrintPath(start, back[finish].parentVert, back);
                System.Console.Write(" -> ");
                System.Console.Write(GetPosName(finish));
            }
        }
        public void DisplayNearestPos(int currentpos, int[,] adjMat)
        {
            int min1 = infinity;
            int min2 = infinity;

            int nearestpos1 = 0;
            int nearestpos2 = 0;

            for (int i = 0; i < adjMat.GetLength(1); i++)
            {
                if (adjMat[currentpos, i] < min1 && adjMat[currentpos, i] != 0)
                {
                    min1 = adjMat[currentpos, i];
                    nearestpos1 = i;
                }
            }
            for (int i = 0; i < adjMat.GetLength(0); i++)
            {
                if (adjMat[i, currentpos] < min2 && adjMat[i, currentpos] != 0)
                {
                    min2 = adjMat[i, currentpos];
                    nearestpos2 = i;
                }
            }
            if (min1 < min2)
            {
                System.Console.Write("\nĐịa điểm gần {0} nhất là: {1}", GetPosName(currentpos), GetPosName(nearestpos1));
            }
            else
            {
                System.Console.Write("\nĐịa điểm gần {0} nhất là: {1}", GetPosName(currentpos), GetPosName(nearestpos2));
            }
        }
        public void BusPath(int n)
        {
            string[] str = new string[n];
            for (int i = 0; i < n; i++)
            {
                str[i] = GetPosName(i + 1);
            }
            System.Console.WriteLine("Lộ trình xe buýt");
            System.Console.Write("Bệnh viện Đại học Y dược");
            for (int i = 0; i < n - 1; i++)
            {
                System.Console.Write(" -> " + str[i]);
            }
            System.Console.Write(" -> " + str[n - 1]);
        }
    }
}