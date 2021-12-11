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
        System.Console.WriteLine("Tuyến đường phải đi là: ");
        PrintPath(0, n, sPath);
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
            switch (finish)
            {
                case 1: System.Console.Write("Đại học kinh tế TP.HCM CSB"); break;
                case 2: System.Console.Write("Chợ Bến Thành"); break;
                case 3: System.Console.Write("Bệnh viện Hùng Vương"); break;
                case 4: System.Console.Write("Trường THPT Mạc Đĩnh Chi"); break;
                case 5: System.Console.Write("Trung tâm mua sắm AEON Mall Bình Tân"); break;
                case 6: System.Console.Write("Đại học Khoa học tự nhiên TPHCM"); break;
                case 7: System.Console.Write("Đài truyền hình HTV"); break;
                default: break;
            }
        }
    }
}
