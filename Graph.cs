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
        Queue<Map> menu = new Queue<Map>();

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
            menu.Enqueue(lab);
            nVerts++;
        }
        public void AddEdge(int start, int end, int weight)
        {
            adjMat[start, end] = weight;
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
        public void Path()
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
            nTree = 0;
            for (int j = 0; j <= nVerts - 1; j++)
                vertexList[j].isInTree = false;
        }
        public void DisplayMenu(int n)
        {
        Begin:
            Console.Clear();
            Path();
            System.Console.WriteLine("Điểm xuất phát: " + vertexList[0].label.getName());
            System.Console.WriteLine("Điểm đến: " + vertexList[n].label.getName());
            System.Console.WriteLine("-----------Những thông tin hữu ích về lộ trình bạn cần biết-----------");
            System.Console.WriteLine("Quãng đường ngắn nhất: 1");
            System.Console.WriteLine("Tuyến đường ngắn nhất: 2");
            System.Console.WriteLine("Tìm địa điểm gần nhất: 3");
            System.Console.WriteLine("Tìm địa điểm xung quanh: 4");
            System.Console.WriteLine("Hiển thị giá tiền theo phương tiện/hãng xe: 5");

        Error:
            System.Console.Write("Nhập lựa chọn của bạn: ");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Console.Clear();
                    System.Console.WriteLine("Quãng đường ngắn nhất từ {0} đến {1} là: {2}", vertexList[0].label.getName(), vertexList[n].label.getName(), sPath[n].distance);
                    break;
                case 2:
                    Console.Clear();
                    System.Console.WriteLine("Tuyến đường ngắn nhất phải đi là: ");
                    PrintPath(0, n, sPath);
                    break;
                case 3:
                    Console.Clear();
                    PrintDes(0);
                Error1:
                    System.Console.Write("Nhập địa điểm bạn muốn: ");
                    int pos1 = Int32.Parse(Console.ReadLine());
                    if (pos1 >= 1 && pos1 <= 7)
                    {
                        DisplayNearestPos(pos1, adjMat);
                    }
                    else
                    {
                        System.Console.WriteLine("\nYêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 7)");
                        goto Error1;
                    }
                    break;
                case 4:
                    Console.Clear();
                    PrintDes(0);
                Error2:
                    System.Console.Write("Nhập địa điểm bạn muốn: ");
                    int pos2 = Int32.Parse(Console.ReadLine());
                    if (pos2 >= 1 && pos2 <= 7)
                    {
                        DisplayNearPos(pos2, adjMat);
                    }
                    else
                    {
                        System.Console.WriteLine("\nYêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 7)");
                        goto Error2;
                    }
                    break;
                case 5:
                    Console.Clear();
                    DisplayCost(n);
                    break;
                default:
                    System.Console.WriteLine("\nYêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 5)");
                    goto Error;
            }           
        Error3:
            System.Console.WriteLine("\nĐể xem thêm thông tin về lộ trình ấn phím 1, để tiếp tục ấn phím 2:");
            int exit = Int32.Parse(Console.ReadLine());
            switch (exit)
            {
                case 1:
                    goto Begin;
                case 2:
                    Console.Clear();
                    break;
                default:
                    System.Console.WriteLine("\nYêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 2)");
                    goto Error3;
            }
        }
        public void PrintDes(int start)
        {
            Queue<Map> clone = new Queue<Map>(menu);
            System.Console.WriteLine("-----------Các điểm đến----------");
            int button = 1;
            while (clone.Count != 0)
            {
                if (start == clone.Peek().getId())
                {
                    clone.Dequeue();
                }
                System.Console.WriteLine("{0}: {1}", clone.Dequeue().getName(), button);
                button++;
            }
        }
        public void DisplayCost(int n)
        {
            System.Console.WriteLine("------------Các loại phương tiện------------");
            System.Console.WriteLine("Xe taxi: Phím 1");
            System.Console.WriteLine("Xe máy: Phím 2");

        Error:
            System.Console.Write("Nhập lựa chọn của bạn: ");
            int numberChoose = Int32.Parse(Console.ReadLine());
            System.Console.WriteLine();
            switch (numberChoose)
            {
                case 1:
                    List<Car> listCar = new List<Car>();
                    Car grabCar = new Car("13203", "Taxi Grab", 45f, 5000f);
                    listCar.Add(grabCar);
                    Car uberCar = new Car("12131", "Taxi Uber", 42f, 4800f);
                    listCar.Add(uberCar);
                    Car maiLinhCar = new Car("14205", "Taxi Mai Linh", 50f, 5500f);
                    listCar.Add(maiLinhCar);
                    System.Console.WriteLine("------------CÁC HÃNG XE TAXI CÔNG NGHỆ------------");
                    System.Console.WriteLine("Grab (5000đ/1km): 0");
                    System.Console.WriteLine("Uber (4800đ/1km): 1");
                    System.Console.WriteLine("Taxi Mai Linh (5500đ/1km): 2");

                Error1:
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
                            System.Console.WriteLine("\nYêu cầu bạn nhập không đúng vui lòng nhập lại! (0 - 2)");
                            goto Error1;
                    }
                    break;
                case 2:
                    List<Motorbike> listMotorbike = new List<Motorbike>();
                    Motorbike grabMotorbike = new Motorbike("21023", "Xe máy Grab", 30f, 2500f);
                    listMotorbike.Add(grabMotorbike);
                    Motorbike uberMotorbike = new Motorbike("25037", "Xe máy Uber", 32f, 2600f);
                    listMotorbike.Add(uberMotorbike);
                    Motorbike beMotorBike = new Motorbike("24306", "Xe máy BE", 29f, 2400f);
                    listMotorbike.Add(beMotorBike);
                    System.Console.WriteLine("------------CÁC HÃNG XE MÁY CÔNG NGHỆ------------");
                    System.Console.WriteLine("Grab (2500đ/1km): Phím 0");
                    System.Console.WriteLine("Uber (2600đ/1km): Phím 1");
                    System.Console.WriteLine("BE (2400đ/1km): Phím 2");

                Error2:
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
                            System.Console.WriteLine("\nYêu cầu bạn nhập không đúng vui lòng nhập lại! (0 - 2)");
                            goto Error2;
                    }
                    break;
                default:
                    System.Console.WriteLine("Yêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 2)");
                    goto Error;
            }

        }
        public void PrintPath(int start, int end, DistOriginal[] back)
        {
            if (start == end)
            {
                System.Console.Write(vertexList[start].label.getName());
            }
            else
            {
                PrintPath(start, back[end].parentVert, back);
                System.Console.Write(" -> ");
                System.Console.Write(vertexList[end].label.getName());
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
                System.Console.WriteLine("\nĐịa điểm gần {0} nhất là: {1}", vertexList[currentpos].label.getName(), vertexList[nearestpos1].label.getName());
            }
            else
            {
                System.Console.WriteLine("\nĐịa điểm gần {0} nhất là: {1}", vertexList[currentpos].label.getName(), vertexList[nearestpos2].label.getName());
            }
        }
        public void DisplayNearPos(int currentpos, int[,] adjMat)
        {
            Console.WriteLine("Những địa điểm xung quanh {0} là: ", vertexList[currentpos].label.getName());
            for (int i = 0; i < adjMat.GetLength(1); i++)
            {
                if (adjMat[currentpos, i] != 0 && adjMat[currentpos, i] < infinity)
                {
                    Console.WriteLine(vertexList[i].label.getName()) ;
                }
            }
        }
    }
}