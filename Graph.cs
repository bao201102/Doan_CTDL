using System;
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
        System.Console.WriteLine(sPath[n].distance);
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
        System.Console.WriteLine("\n----------Các phương tiện------------");
        System.Console.WriteLine("Xe buýt: Phím 1");
        System.Console.WriteLine("Xe hơi: Phím 2");
        System.Console.WriteLine("Xe máy Grab: Phím 3");

    Error:
        System.Console.Write("Chọn phương tiện cần xem chi phí: ");
        int numberChoose = Int32.Parse(Console.ReadLine());
        switch (numberChoose)
        {
            case 1:
                float busCost = sPath[n].distance * 500;
                System.Console.WriteLine("Tiền đi xe buýt: " + busCost);
                break;
            case 2:
                float carCost = sPath[n].distance * 3000;
                System.Console.WriteLine("Tiền đi xe hơi: " + carCost);
                break;
            case 3:
                float grabCost = sPath[n].distance * 1500;
                System.Console.WriteLine("Tiền đi xe máy Grab: " + grabCost);
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

        for (int i = 1; i < adjMat.GetLength(1); i++)
        {
            if (adjMat[currentpos, i] < min1 && adjMat[currentpos, i] != 0)
            {
                min1 = adjMat[currentpos, i];
                nearestpos1 = i;
            }
        }
        for (int i = 1; i < adjMat.GetLength(0); i++)
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
}
