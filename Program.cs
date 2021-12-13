using System;

namespace baithi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Graph map = new Graph();
            Map bv_daihoc = new Map(50, 20, "Bệnh viện Đại học Y dược", "02040", "Quận 5", "TP.HCM"); //0
            map.AddVertex(bv_daihoc);
            Map ueh = new Map(40, 53.2f, "Đại học kinh tế TP.HCM CSB", "02241", "Quận 10", "TP.HCM"); //1
            map.AddVertex(ueh);
            Map chobenthanh = new Map(82.4f, 20, "Chợ Bến Thành", "23459", "Quận 1", "TP.HCM"); //2
            map.AddVertex(chobenthanh);
            Map bv_hungvuong = new Map(50, 20, "Bệnh viện Hùng Vương", "22158", "Quận 5", "TP.HCM"); //3
            map.AddVertex(bv_hungvuong);
            Map macdinhchi = new Map(20, 30.5f, "Trường THPT Mạc Đĩnh Chi", "020104", "Quận 6", "TP.HCM"); //4
            map.AddVertex(macdinhchi);
            Map aeon = new Map(20.3f, 302.4f, "Trung tâm mua sắm AEON Mall Bình Tân", "132013", "Bình Tân", "TP.HCM"); //5
            map.AddVertex(aeon);
            Map khtn = new Map(49.2f, 90.2f, "Đại học Khoa học tự nhiên TPHCM", "360709", "Quận 8", "TP.HCM"); //6
            map.AddVertex(khtn);
            Map htv = new Map(20.4f, 30.2f, "Đài truyền hình HTV", "112394", "Quận 1", "TP.HCM"); //7
            map.AddVertex(htv);

            map.AddEdge(0, 1, 2); map.AddEdge(0, 3, 4); map.AddEdge(0, 4, 2);
            map.AddEdge(1, 2, 6); map.AddEdge(1, 4, 3); map.AddEdge(1, 6, 4);
            map.AddEdge(2, 5, 12); map.AddEdge(2, 6, 7); map.AddEdge(2, 7, 5);
            map.AddEdge(3, 5, 3); map.AddEdge(3, 6, 9);
            map.AddEdge(4, 5, 1); map.AddEdge(4, 7, 14);
            map.AddEdge(5, 6, 8); map.AddEdge(6, 7, 4);

        Begin:
            Console.Clear();
            System.Console.WriteLine("\t\tĐỒ ÁN: CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT");
            System.Console.WriteLine("*****************************************************************");
            System.Console.WriteLine("Điểm xuất phát: Bệnh viện đại học Y Dược ");
            System.Console.WriteLine("------------Các điểm đến------------");
            System.Console.WriteLine("Đại học kinh tế TP.HCM: Phím 1");
            System.Console.WriteLine("Chợ Bến Thành: Phím 2");
            System.Console.WriteLine("Bệnh viện Hùng Vương: Phím 3");
            System.Console.WriteLine("Trường THPT Mạc Đĩnh Chi: Phím 4");
            System.Console.WriteLine("Trung tâm mua sắm AEON Mall Bình Tân: Phím 5");
            System.Console.WriteLine("Đại học Khoa học tự nhiên TPHCM: Phím 6");
            System.Console.WriteLine("Đài truyền hình HTV: Phím 7");
            System.Console.WriteLine("*****************************************************************");

        Error1:
            System.Console.Write("Chọn địa điểm cần đến (nhập 8 để thoát chương trình): ");
            int choose1 = Int32.Parse(Console.ReadLine());
            switch (choose1)
            {
                case 1:
                    Console.Clear();
                    System.Console.WriteLine("Địa điểm bạn chọn là: " + ueh.ToString());
                    map.Path(choose1);
                    break;
                case 2:
                    Console.Clear();
                    System.Console.WriteLine("Địa điểm bạn chọn là: " + chobenthanh.ToString());
                    map.Path(choose1);
                    break;
                case 3:
                    Console.Clear();
                    System.Console.WriteLine("Địa điểm bạn chọn là: " + bv_hungvuong.ToString());
                    map.Path(choose1);
                    break;
                case 4:
                    Console.Clear();
                    System.Console.WriteLine("Địa điểm bạn chọn là: " + macdinhchi.ToString());
                    map.Path(choose1);
                    break;
                case 5:
                    Console.Clear();
                    System.Console.WriteLine("Địa điểm bạn chọn là: " + aeon.ToString());
                    map.Path(choose1);
                    break;
                case 6:
                    Console.Clear();
                    System.Console.WriteLine("Địa điểm bạn chọn là: " + khtn.ToString());
                    map.Path(choose1);
                    break;
                case 7:
                    Console.Clear();
                    System.Console.WriteLine("Địa điểm bạn chọn là: " + htv.ToString());
                    map.Path(choose1);
                    break;
                case 8:
                    System.Console.WriteLine("Bạn đã thoát chương trình");
                    break;
                default:
                    System.Console.WriteLine("Yêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 8)");
                    goto Error1;
            }

            System.Console.WriteLine("\nBạn đã tham khảo các thông tin hữu ích về địa điểm trên xong!");
        Error2:
            System.Console.WriteLine("Để tiếp tục sử dụng chương trình ấn phím 1, để thoát chương trình ấn phím 2:");
            int choose2 = Int32.Parse(Console.ReadLine());
            switch (choose2)
            {
                case 1:
                    goto Begin;
                case 2:
                    System.Console.WriteLine("Bạn đã thoát chương trình");
                    break;
                default:
                    System.Console.WriteLine("Yêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 2)");
                    goto Error2;
            }
        }
    }
}
