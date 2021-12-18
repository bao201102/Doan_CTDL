using System;
using System.Collections.Generic;

namespace baithi
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Map bv_daihoc = new Map(50, 20, "Bệnh viện Đại học Y dược", 0, "Quận 5", "TP.HCM"); //0
            Map ueh = new Map(40, 53.2f, "Đại học kinh tế TP.HCM CSB", 1, "Quận 10", "TP.HCM"); //1
            Map chobenthanh = new Map(82.4f, 20, "Chợ Bến Thành", 2, "Quận 1", "TP.HCM"); //2
            Map bv_hungvuong = new Map(50, 20, "Bệnh viện Hùng Vương", 3, "Quận 5", "TP.HCM"); //3
            Map macdinhchi = new Map(20, 30.5f, "Trường THPT Mạc Đĩnh Chi", 4, "Quận 6", "TP.HCM"); //4
            Map aeon = new Map(20.3f, 302.4f, "Trung tâm mua sắm AEON Mall Bình Tân", 5, "Bình Tân", "TP.HCM"); //5
            Map khtn = new Map(49.2f, 90.2f, "Đại học Khoa học tự nhiên TPHCM", 6, "Quận 8", "TP.HCM"); //6
            Map htv = new Map(20.4f, 30.2f, "Đài truyền hình HTV", 7, "Quận 1", "TP.HCM"); //7

            List<Map> listpos = new List<Map>();
            listpos.Add(bv_daihoc); listpos.Add(ueh);
            listpos.Add(chobenthanh); listpos.Add(bv_hungvuong);
            listpos.Add(macdinhchi); listpos.Add(aeon);
            listpos.Add(khtn); listpos.Add(htv);

            Graph map = new Graph();
            map.AddVertex(bv_daihoc);
            map.AddVertex(ueh);
            map.AddVertex(chobenthanh);
            map.AddVertex(bv_hungvuong);
            map.AddVertex(macdinhchi);
            map.AddVertex(aeon);
            map.AddVertex(khtn);
            map.AddVertex(htv);
            map.AddEdge(0, 1, 2); map.AddEdge(0, 3, 4); map.AddEdge(0, 4, 2);
            map.AddEdge(1, 2, 6); map.AddEdge(1, 4, 3); map.AddEdge(1, 6, 4); 
            map.AddEdge(2, 5, 12); map.AddEdge(2, 6, 7); map.AddEdge(2, 7, 5);
            map.AddEdge(3, 5, 3); map.AddEdge(3, 6, 9); 
            map.AddEdge(4, 5, 1); map.AddEdge(4, 7, 14); 
            map.AddEdge(5, 6, 8); 
            map.AddEdge(6, 7, 4);

        Begin:
            Console.Clear();
            System.Console.WriteLine("=========ĐỒ ÁN MÔN HỌC CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT=========");
            System.Console.WriteLine("  ĐỀ TÀI: ĐỒ THỊ VÀ ỨNG DỤNG TRONG QUẢN LÍ LỘ TRÌNH ĐƯỜNG ĐI  ");
            System.Console.WriteLine("           NHÓM THỰC HIỆN: BẢO, DẬU, ĐẠT, THIỆN");
            System.Console.WriteLine("                 ************************                     ");
            System.Console.WriteLine("---------------PHẦN MỀM QUẢN LÍ LỘ TRÌNH ĐƯỜNG ĐI-------------");
            System.Console.WriteLine("____________________Các địa điểm trên bản đồ__________________");
            System.Console.WriteLine("1. Bệnh viện đại học Y Dược");
            System.Console.WriteLine("2. Trường đại học Kinh tế TP.HCM");
            System.Console.WriteLine("3. Chợ Bến Thành");
            System.Console.WriteLine("4. Bệnh viện Hùng Vương");
            System.Console.WriteLine("5. Trường THPT Mạc Đĩnh Chi");
            System.Console.WriteLine("6. Trung tâm mua sắm AEON Mall Bình Tân");
            System.Console.WriteLine("7. Đại học Khoa học tự nhiên TP.HCM");
            System.Console.WriteLine("8. Đài truyền hình HTV");
            System.Console.WriteLine("==============================================================");
            System.Console.WriteLine("Tìm địa điểm theo từ khóa: Phím 1");
            System.Console.WriteLine("Tìm địa điểm gần nhất: Phím 2");
            System.Console.WriteLine("Tìm địa điểm xung quanh: Phím 3");
            System.Console.WriteLine("Tìm thông tin theo lộ trình: Phím 4");

        Error1:
            System.Console.Write("Nhập lựa chọn của bạn: ");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Nhập từ khóa cần tìm kiếm: ");
                    string text = Console.ReadLine();
                    System.Console.WriteLine("------------------------------------");
                    Console.WriteLine("Địa điểm bạn cần tìm là: ");
                    for (int i = 0; i < listpos.Count; i++)
                    {
                        if (listpos[i].getName().ToLower().Contains(text.ToLower()))
                        {
                            Console.WriteLine(listpos[i].getName());
                        }
                    }
                    break;

                case 2:
                    Console.Clear();
                    map.PrintDes(-1);
                FError1:
                    System.Console.Write("Nhập địa điểm bạn muốn: ");
                    int pos1 = Int32.Parse(Console.ReadLine()) - 1;
                    System.Console.WriteLine("------------------------------------");
                    if (pos1 >= 0 && pos1 <= 7)
                    {
                        map.DisplayNearestPos(pos1);
                    }
                    else
                    {
                        System.Console.WriteLine("\nYêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 8)");
                        goto FError1;
                    }
                    break;

                case 3:
                    Console.Clear();
                    map.PrintDes(-1);
                FError2:
                    System.Console.Write("Nhập địa điểm bạn muốn: ");
                    int pos2 = Int32.Parse(Console.ReadLine()) - 1;
                    System.Console.WriteLine("------------------------------------");
                    if (pos2 >= 0 && pos2 <= 7)
                    {
                        map.DisplayNearPos(pos2);
                    }
                    else
                    {
                        System.Console.WriteLine("\nYêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 7)");
                        goto FError2;
                    }
                    break;

                case 4:
                    System.Console.Write("Nhập địa điểm xuất phát: ");
                    string startPos = Console.ReadLine();
                    System.Console.Write("Nhập điểm đến: ");
                    string endPos = Console.ReadLine();
                    map.DisplayMenu(startPos, endPos);
                    break;

                default:
                    System.Console.WriteLine("------------------------------------");
                    System.Console.WriteLine("Yêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 4)");
                    goto Error1;
            }

        Error2:
            System.Console.Write("Để tiếp tục sử dụng chương trình ấn phím 1, để thoát chương trình ấn phím 2: ");
            int end = Int32.Parse(Console.ReadLine());
            switch (end)
            {
                case 1:
                    goto Begin;

                case 2:
                    Console.Clear();
                    System.Console.WriteLine("Bạn đã thoát chương trình");
                    break;

                default:
                    System.Console.WriteLine("------------------------------------");
                    System.Console.WriteLine("Yêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 2)");
                    goto Error2;
            }
        }
    }
}