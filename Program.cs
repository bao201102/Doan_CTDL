using System;
using System.Collections.Generic;

namespace baithi
{
    class Program
    {
        static void ChooseEnd(Graph map)
        {
            System.Console.Write("Chọn địa điểm cần đến (gõ phím tương ứng trên menu): ");
            int end = Int32.Parse(Console.ReadLine());
            if (end >= 1 && end <= 7)
            {
                map.DisplayMenu(end);
            }
            else
            {
                Console.WriteLine("\nYêu cầu bạn nhập không đúng. Chỉ nhập từ 1 - 7");
                ChooseEnd(map);
            }
        }
        static void FindByName(ref List<Map> listMap, string name)
        {
            for (int i = 0; i < listMap.Count; i++)
            {
                if (listMap[i].getName().ToLower() == name)
                {
                    System.Console.WriteLine("Thông tin về địa điểm bạn cần tìm là: " + listMap[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Map bv_daihoc = new Map(50, 20, "Bệnh viện Đại học Y dược", "02040", "Quận 5", "TP.HCM"); //0
            Map ueh = new Map(40, 53.2f, "Đại học kinh tế TP.HCM CSB", "02241", "Quận 10", "TP.HCM"); //1
            Map chobenthanh = new Map(82.4f, 20, "Chợ Bến Thành", "23459", "Quận 1", "TP.HCM"); //2
            Map bv_hungvuong = new Map(50, 20, "Bệnh viện Hùng Vương", "22158", "Quận 5", "TP.HCM"); //3
            Map macdinhchi = new Map(20, 30.5f, "Trường THPT Mạc Đĩnh Chi", "020104", "Quận 6", "TP.HCM"); //4
            Map aeon = new Map(20.3f, 302.4f, "Trung tâm mua sắm AEON Mall Bình Tân", "132013", "Bình Tân", "TP.HCM"); //5
            Map khtn = new Map(49.2f, 90.2f, "Đại học Khoa học tự nhiên TPHCM", "360709", "Quận 8", "TP.HCM"); //6
            Map htv = new Map(20.4f, 30.2f, "Đài truyền hình HTV", "112394", "Quận 1", "TP.HCM"); //7

            Console.Clear();
            // List<Map> mapList = new List<Map>();

            // mapList.Add(bv_daihoc); mapList.Add(ueh);
            // mapList.Add(chobenthanh); mapList.Add(bv_hungvuong);
            // mapList.Add(macdinhchi); mapList.Add(aeon);
            // mapList.Add(khtn); mapList.Add(htv);
            // System.Console.WriteLine(mapList[1].getName().ToLower());
            // System.Console.Write("Nhập vào tên địa điểm bạn muốn tra thông tin: ");
            // string name = Console.ReadLine();
            // FindByName(ref mapList, name);

            //Console.Clear();
            Graph mapNear = new Graph();
            mapNear.AddVertex(bv_daihoc);
            mapNear.AddVertex(ueh);
            mapNear.AddVertex(chobenthanh);
            mapNear.AddVertex(bv_hungvuong);
            mapNear.AddVertex(macdinhchi);
            mapNear.AddVertex(aeon);
            mapNear.AddVertex(khtn);
            mapNear.AddVertex(htv);
            mapNear.AddEdge(0, 1, 2); mapNear.AddEdge(0, 3, 4); mapNear.AddEdge(0, 4, 2);
            mapNear.AddEdge(1, 2, 6); mapNear.AddEdge(1, 4, 3); mapNear.AddEdge(1, 6, 4); mapNear.AddEdge(1, 0, 2);
            mapNear.AddEdge(2, 5, 12); mapNear.AddEdge(2, 6, 7); mapNear.AddEdge(2, 7, 5); mapNear.AddEdge(2, 1, 6);
            mapNear.AddEdge(3, 5, 3); mapNear.AddEdge(3, 6, 9); mapNear.AddEdge(3, 0, 4);
            mapNear.AddEdge(4, 5, 1); mapNear.AddEdge(4, 7, 14); mapNear.AddEdge(4, 1, 3); mapNear.AddEdge(4, 0, 2);
            mapNear.AddEdge(5, 6, 8); mapNear.AddEdge(5, 2, 12); mapNear.AddEdge(5, 3, 3); mapNear.AddEdge(5, 4, 1);
            mapNear.AddEdge(6, 7, 4); mapNear.AddEdge(6, 1, 4); mapNear.AddEdge(6, 2, 7); mapNear.AddEdge(6, 3, 9); mapNear.AddEdge(6, 5, 8);
            mapNear.AddEdge(7, 2, 5); mapNear.AddEdge(7, 4, 14); mapNear.AddEdge(7, 6, 4);

            mapNear.FindNearestPos();
            System.Console.WriteLine();

        Begin:
            System.Console.WriteLine("-----------Các điểm xuất phát----------");
            System.Console.WriteLine("Bệnh viện đại học Y Dược: Phím 0");
            System.Console.WriteLine("Đại học kinh tế TP.HCM: Phím 1");
            System.Console.WriteLine("Chợ Bến Thành: Phím 2");
            System.Console.WriteLine("Bệnh viện Hùng Vương: Phím 3");
            System.Console.WriteLine("Trường THPT Mạc Đĩnh Chi: Phím 4");
            System.Console.WriteLine("Trung tâm mua sắm AEON Mall Bình Tân: Phím 5");
            System.Console.WriteLine("Đại học Khoa học tự nhiên TPHCM: Phím 6");
            System.Console.WriteLine("Đài truyền hình HTV: Phím 7");

        Error1:
            System.Console.Write("Nhập lựa chọn của bạn: ");
            int start = Int32.Parse(Console.ReadLine());
            switch (start)
            {
                case 0:
                    Console.Clear();
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
                    map.AddEdge(1, 2, 6); map.AddEdge(1, 4, 3); map.AddEdge(1, 6, 4); map.AddEdge(1, 0, 2);
                    map.AddEdge(2, 5, 12); map.AddEdge(2, 6, 7); map.AddEdge(2, 7, 5); map.AddEdge(2, 1, 6);
                    map.AddEdge(3, 5, 3); map.AddEdge(3, 6, 9); map.AddEdge(3, 0, 4);
                    map.AddEdge(4, 5, 1); map.AddEdge(4, 7, 14); map.AddEdge(4, 1, 3); map.AddEdge(4, 0, 2);
                    map.AddEdge(5, 6, 8); map.AddEdge(5, 2, 12); map.AddEdge(5, 3, 3); map.AddEdge(5, 4, 1);
                    map.AddEdge(6, 7, 4); map.AddEdge(6, 1, 4); map.AddEdge(6, 2, 7); map.AddEdge(6, 3, 9); map.AddEdge(6, 5, 8);
                    map.AddEdge(7, 2, 5); map.AddEdge(7, 4, 14); map.AddEdge(7, 6, 4);

                    System.Console.WriteLine("Điểm xuất phát:  " + bv_daihoc.getName());
                    System.Console.WriteLine("----------Các điểm đến------------");
                    System.Console.WriteLine("Đại học kinh tế TP.HCM: Phím 1");
                    System.Console.WriteLine("Chợ Bến Thành: Phím 2");
                    System.Console.WriteLine("Bệnh viện Hùng Vương: Phím 3");
                    System.Console.WriteLine("Trường THPT Mạc Đĩnh Chi: Phím 4");
                    System.Console.WriteLine("Trung tâm mua sắm AEON Mall Bình Tân: Phím 5");
                    System.Console.WriteLine("Đại học Khoa học tự nhiên TPHCM: Phím 6");
                    System.Console.WriteLine("Đài truyền hình HTV: Phím 7");
                    ChooseEnd(map);
                    break;

                case 1:
                    Console.Clear();
                    Graph map1 = new Graph();
                    map1.AddVertex(ueh);
                    map1.AddVertex(bv_daihoc);
                    map1.AddVertex(chobenthanh);
                    map1.AddVertex(bv_hungvuong);
                    map1.AddVertex(macdinhchi);
                    map1.AddVertex(aeon);
                    map1.AddVertex(khtn);
                    map1.AddVertex(htv);
                    map1.AddEdge(0, 1, 2); map1.AddEdge(0, 2, 6); map1.AddEdge(0, 4, 3); map1.AddEdge(0, 6, 4);
                    map1.AddEdge(1, 3, 4); map1.AddEdge(1, 4, 2); map1.AddEdge(1, 0, 2);
                    map1.AddEdge(2, 5, 12); map1.AddEdge(2, 6, 7); map1.AddEdge(2, 7, 5); map1.AddEdge(2, 0, 6);
                    map1.AddEdge(3, 5, 3); map1.AddEdge(3, 6, 9); map1.AddEdge(3, 1, 4);
                    map1.AddEdge(4, 5, 1); map1.AddEdge(4, 7, 14); map1.AddEdge(4, 1, 2); map1.AddEdge(4, 0, 3);
                    map1.AddEdge(5, 6, 8); map1.AddEdge(5, 2, 12); map1.AddEdge(5, 3, 3); map1.AddEdge(5, 4, 1);
                    map1.AddEdge(6, 7, 4); map1.AddEdge(6, 2, 7); map1.AddEdge(6, 3, 9); map1.AddEdge(6, 5, 8); map1.AddEdge(6, 0, 4);
                    map1.AddEdge(7, 2, 5); map1.AddEdge(7, 4, 14); map1.AddEdge(7, 6, 4);

                    System.Console.WriteLine("Điểm xuất phát: " + ueh.getName());
                    System.Console.WriteLine("----------Các điểm đến------------");
                    System.Console.WriteLine("Bệnh viện đại học Y Dược: Phím 1");
                    System.Console.WriteLine("Chợ Bến Thành: Phím 2");
                    System.Console.WriteLine("Bệnh viện Hùng Vương: Phím 3");
                    System.Console.WriteLine("Trường THPT Mạc Đĩnh Chi: Phím 4");
                    System.Console.WriteLine("Trung tâm mua sắm AEON Mall Bình Tân: Phím 5");
                    System.Console.WriteLine("Đại học Khoa học tự nhiên TPHCM: Phím 6");
                    System.Console.WriteLine("Đài truyền hình HTV: Phím 7");
                    ChooseEnd(map1);
                    break;

                case 2:
                    Console.Clear();
                    Graph map2 = new Graph();
                    map2.AddVertex(chobenthanh); map2.AddVertex(ueh);
                    map2.AddVertex(bv_daihoc); map2.AddVertex(bv_hungvuong);
                    map2.AddVertex(macdinhchi); map2.AddVertex(aeon);
                    map2.AddVertex(khtn); map2.AddVertex(htv);
                    map2.AddEdge(0, 1, 6); map2.AddEdge(0, 5, 12); map2.AddEdge(0, 6, 7); map2.AddEdge(0, 7, 5);
                    map2.AddEdge(1, 2, 2); map2.AddEdge(1, 4, 3); map2.AddEdge(1, 6, 4); map2.AddEdge(1, 0, 6);
                    map2.AddEdge(2, 3, 4); map2.AddEdge(2, 4, 2); map2.AddEdge(2, 1, 2);
                    map2.AddEdge(3, 5, 3); map2.AddEdge(3, 6, 9); map2.AddEdge(3, 2, 4);
                    map2.AddEdge(4, 5, 1); map2.AddEdge(4, 7, 14); map2.AddEdge(4, 1, 3); map2.AddEdge(4, 2, 2);
                    map2.AddEdge(5, 6, 8); map2.AddEdge(5, 3, 3); map2.AddEdge(5, 4, 1); map2.AddEdge(5, 0, 12);
                    map2.AddEdge(6, 7, 4); map2.AddEdge(6, 1, 4); map2.AddEdge(6, 3, 9); map2.AddEdge(6, 5, 8); map2.AddEdge(6, 0, 7);
                    map2.AddEdge(7, 4, 14); map2.AddEdge(7, 6, 4); map2.AddEdge(7, 0, 5);

                    System.Console.WriteLine("Điểm xuất phát: " + chobenthanh.getName());
                    System.Console.WriteLine("----------Các điểm đến------------");
                    System.Console.WriteLine("Đại học kinh tế TP.HCM: Phím 1");
                    System.Console.WriteLine("Bệnh viện đại học Y Dược: Phím 2");
                    System.Console.WriteLine("Bệnh viện Hùng Vương: Phím 3");
                    System.Console.WriteLine("Trường THPT Mạc Đĩnh Chi: Phím 4");
                    System.Console.WriteLine("Trung tâm mua sắm AEON Mall Bình Tân: Phím 5");
                    System.Console.WriteLine("Đại học Khoa học tự nhiên TPHCM: Phím 6");
                    System.Console.WriteLine("Đài truyền hình HTV: Phím 7");
                    ChooseEnd(map2);
                    break;

                case 3:
                    Console.Clear();
                    Graph map3 = new Graph();
                    map3.AddVertex(bv_hungvuong); map3.AddVertex(bv_daihoc);
                    map3.AddVertex(ueh); map3.AddVertex(chobenthanh);
                    map3.AddVertex(macdinhchi); map3.AddVertex(aeon);
                    map3.AddVertex(khtn); map3.AddVertex(htv);
                    map3.AddEdge(0, 1, 4); map3.AddEdge(0, 5, 3); map3.AddEdge(0, 6, 9);
                    map3.AddEdge(1, 4, 2); map3.AddEdge(1, 2, 2); map3.AddEdge(1, 0, 4);
                    map3.AddEdge(2, 4, 3); map3.AddEdge(2, 6, 4); map3.AddEdge(2, 3, 6); map3.AddEdge(2, 1, 2);
                    map3.AddEdge(3, 5, 12); map3.AddEdge(3, 6, 7); map3.AddEdge(3, 7, 4); map3.AddEdge(3, 2, 6);
                    map3.AddEdge(4, 5, 1); map3.AddEdge(4, 7, 14); map3.AddEdge(4, 1, 2); map3.AddEdge(4, 2, 3);
                    map3.AddEdge(5, 6, 8); map3.AddEdge(5, 3, 12); map3.AddEdge(5, 4, 1); map3.AddEdge(5, 0, 3);
                    map3.AddEdge(6, 7, 4); map3.AddEdge(6, 2, 4); map3.AddEdge(6, 3, 7); map3.AddEdge(6, 5, 8); map3.AddEdge(6, 0, 9);
                    map3.AddEdge(7, 3, 4); map3.AddEdge(7, 4, 14); map3.AddEdge(7, 6, 4);

                    System.Console.WriteLine("Điểm xuất phát: " + bv_hungvuong.getName());
                    System.Console.WriteLine("----------Các điểm đến------------");
                    System.Console.WriteLine("Bệnh viện đại học Y Dược: Phím 1");
                    System.Console.WriteLine("Đại học kinh tế TP.HCM: Phím 2");
                    System.Console.WriteLine("Chợ Bến Thành: Phím 3");
                    System.Console.WriteLine("Trường THPT Mạc Đĩnh Chi: Phím 4");
                    System.Console.WriteLine("Trung tâm mua sắm AEON Mall Bình Tân: Phím 5");
                    System.Console.WriteLine("Đại học Khoa học tự nhiên TPHCM: Phím 6");
                    System.Console.WriteLine("Đài truyền hình HTV: Phím 7");
                    ChooseEnd(map3);
                    break;

                case 4:
                    Console.Clear();
                    Graph map4 = new Graph();
                    map4.AddVertex(macdinhchi); map4.AddVertex(bv_daihoc);
                    map4.AddVertex(ueh); map4.AddVertex(chobenthanh);
                    map4.AddVertex(bv_hungvuong); map4.AddVertex(aeon);
                    map4.AddVertex(khtn); map4.AddVertex(htv);
                    map4.AddEdge(0, 1, 2); map4.AddEdge(0, 2, 3); map4.AddEdge(0, 5, 1); map4.AddEdge(0, 7, 14);
                    map4.AddEdge(1, 4, 4); map4.AddEdge(1, 2, 2); map4.AddEdge(1, 0, 2);
                    map4.AddEdge(2, 6, 4); map4.AddEdge(2, 3, 6); map4.AddEdge(2, 1, 2); map4.AddEdge(2, 0, 3);
                    map4.AddEdge(3, 5, 12); map4.AddEdge(3, 6, 7); map4.AddEdge(3, 7, 5); map4.AddEdge(3, 2, 6);
                    map4.AddEdge(4, 5, 3); map4.AddEdge(4, 6, 9); map4.AddEdge(4, 1, 4);
                    map4.AddEdge(5, 6, 8); map4.AddEdge(5, 3, 12); map4.AddEdge(5, 4, 3); map4.AddEdge(5, 0, 1);
                    map4.AddEdge(6, 7, 4); map4.AddEdge(6, 2, 4); map4.AddEdge(6, 3, 7); map4.AddEdge(6, 4, 9); map4.AddEdge(6, 5, 8);
                    map4.AddEdge(7, 3, 5); map4.AddEdge(7, 6, 4); map4.AddEdge(7, 0, 14);

                    System.Console.WriteLine("Điểm xuất phát: " + macdinhchi.getName());
                    System.Console.WriteLine("----------Các điểm đến------------");
                    System.Console.WriteLine("Bệnh viện đại học Y Dược: Phím 1");
                    System.Console.WriteLine("Đại học kinh tế TP.HCM: Phím 2");
                    System.Console.WriteLine("Chợ Bến Thành: Phím 3");
                    System.Console.WriteLine("Bệnh viện Hùng Vương: Phím 4");
                    System.Console.WriteLine("Trung tâm mua sắm AEON Mall Bình Tân: Phím 5");
                    System.Console.WriteLine("Đại học Khoa học tự nhiên TPHCM: Phím 6");
                    System.Console.WriteLine("Đài truyền hình HTV: Phím 7");
                    ChooseEnd(map4);
                    break;

                case 5:
                    Console.Clear();
                    Graph map5 = new Graph();
                    map5.AddVertex(aeon); map5.AddVertex(bv_hungvuong);
                    map5.AddVertex(bv_daihoc); map5.AddVertex(ueh);
                    map5.AddVertex(macdinhchi); map5.AddVertex(chobenthanh);
                    map5.AddVertex(khtn); map5.AddVertex(htv);
                    map5.AddEdge(0, 1, 3); map5.AddEdge(0, 4, 1); map5.AddEdge(0, 6, 8); map5.AddEdge(0, 5, 2);
                    map5.AddEdge(1, 2, 4); map5.AddEdge(1, 6, 9); map5.AddEdge(1, 0, 3);
                    map5.AddEdge(2, 4, 2); map5.AddEdge(2, 3, 2); map5.AddEdge(2, 1, 4);
                    map5.AddEdge(3, 4, 3); map5.AddEdge(3, 6, 4); map5.AddEdge(3, 5, 6); map5.AddEdge(3, 2, 2);
                    map5.AddEdge(4, 7, 14); map5.AddEdge(4, 2, 2); map5.AddEdge(4, 3, 3); map5.AddEdge(4, 0, 1);
                    map5.AddEdge(5, 6, 7); map5.AddEdge(5, 7, 5); map5.AddEdge(5, 3, 6); map5.AddEdge(5, 0, 2);
                    map5.AddEdge(6, 7, 4); map5.AddEdge(6, 1, 9); map5.AddEdge(6, 3, 4); map5.AddEdge(6, 5, 7); map5.AddEdge(6, 0, 8);
                    map5.AddEdge(7, 4, 14); map5.AddEdge(7, 5, 5); map5.AddEdge(7, 6, 4);

                    System.Console.WriteLine("Điểm xuất phát: " + aeon.getName());
                    System.Console.WriteLine("----------Các điểm đến------------");
                    System.Console.WriteLine("Bệnh viện Hùng Vương: Phím 1");
                    System.Console.WriteLine("Bệnh viện đại học Y dược: Phím 2");
                    System.Console.WriteLine("Đại học kinh tế TP.HCM: Phím 3");
                    System.Console.WriteLine("Trường THPT Mạc Đĩnh Chi: Phím 4");
                    System.Console.WriteLine("Chợ Bến Thành: Phím 5");
                    System.Console.WriteLine("Đại học Khoa học tự nhiên TPHCM: Phím 6");
                    System.Console.WriteLine("Đài truyền hình HTV: Phím 7");
                    ChooseEnd(map5);
                    break;

                case 6:
                    Console.Clear();
                    Graph map6 = new Graph();
                    map6.AddVertex(khtn); map6.AddVertex(htv);
                    map6.AddVertex(chobenthanh); map6.AddVertex(ueh);
                    map6.AddVertex(macdinhchi); map6.AddVertex(aeon);
                    map6.AddVertex(bv_hungvuong); map6.AddVertex(bv_daihoc);
                    map6.AddEdge(0, 1, 4); map6.AddEdge(0, 2, 7); map6.AddEdge(0, 3, 4); map6.AddEdge(0, 5, 8); map6.AddEdge(0, 6, 9);
                    map6.AddEdge(1, 4, 14); map6.AddEdge(1, 2, 5); map6.AddEdge(1, 0, 4);
                    map6.AddEdge(2, 3, 6); map6.AddEdge(2, 5, 12); map6.AddEdge(2, 1, 5); map6.AddEdge(2, 0, 7);
                    map6.AddEdge(3, 4, 3); map6.AddEdge(3, 7, 2); map6.AddEdge(3, 2, 6); map6.AddEdge(3, 0, 4);
                    map6.AddEdge(4, 7, 2); map6.AddEdge(4, 5, 1); map6.AddEdge(4, 1, 14); map6.AddEdge(4, 3, 3);
                    map6.AddEdge(5, 6, 3); map6.AddEdge(5, 2, 12); map6.AddEdge(5, 4, 1); map6.AddEdge(5, 0, 8);
                    map6.AddEdge(6, 7, 4); map6.AddEdge(6, 5, 3); map6.AddEdge(6, 0, 9);
                    map6.AddEdge(7, 3, 2); map6.AddEdge(7, 4, 2); map6.AddEdge(7, 6, 4);

                    System.Console.WriteLine("Điểm xuất phát: " + khtn.getName());
                    System.Console.WriteLine("----------Các điểm đến------------");
                    System.Console.WriteLine("Đài truyền hình HTV: Phím 1");
                    System.Console.WriteLine("Chợ Bến Thành: Phím 2");
                    System.Console.WriteLine("Đại học kinh tế TP.HCM: Phím 3");
                    System.Console.WriteLine("Trường THPT Mạc Đĩnh Chi: Phím 4");
                    System.Console.WriteLine("Trung tâm mua sắm AEON Mall Bình Tân: Phím 5");
                    System.Console.WriteLine("Bệnh viện Hùng Vương: Phím 6");
                    System.Console.WriteLine("Bệnh viện đại học Y dược: Phím 7");
                    ChooseEnd(map6);
                    break;

                case 7:
                    Console.Clear();
                    Graph map7 = new Graph();
                    map7.AddVertex(htv); map7.AddVertex(khtn);
                    map7.AddVertex(chobenthanh); map7.AddVertex(ueh);
                    map7.AddVertex(macdinhchi); map7.AddVertex(aeon);
                    map7.AddVertex(bv_hungvuong); map7.AddVertex(bv_daihoc);
                    map7.AddEdge(0, 1, 4); map7.AddEdge(0, 4, 14); map7.AddEdge(0, 2, 5);
                    map7.AddEdge(1, 2, 7); map7.AddEdge(1, 3, 4); map7.AddEdge(1, 5, 8); map7.AddEdge(1, 6, 9); map7.AddEdge(1, 0, 4);
                    map7.AddEdge(2, 5, 12); map7.AddEdge(2, 3, 6); map7.AddEdge(2, 1, 7); map7.AddEdge(2, 0, 5);
                    map7.AddEdge(3, 4, 3); map7.AddEdge(3, 7, 2); map7.AddEdge(3, 1, 4); map7.AddEdge(3, 2, 6);
                    map7.AddEdge(4, 7, 2); map7.AddEdge(4, 5, 1); map7.AddEdge(4, 3, 3); map7.AddEdge(4, 0, 14);
                    map7.AddEdge(5, 6, 3); map7.AddEdge(5, 1, 8); map7.AddEdge(5, 2, 12); map7.AddEdge(5, 4, 1);
                    map7.AddEdge(6, 7, 4); map7.AddEdge(6, 1, 9); map7.AddEdge(6, 5, 3);
                    map7.AddEdge(7, 3, 2); map7.AddEdge(7, 4, 2); map7.AddEdge(7, 6, 4);

                    System.Console.WriteLine("Điểm xuất phát: " + htv.getName());
                    System.Console.WriteLine("----------Các điểm đến------------");
                    System.Console.WriteLine("Đại học Khoa học tự nhiên TPHCM: Phím 1");
                    System.Console.WriteLine("Chợ Bến Thành: Phím 2");
                    System.Console.WriteLine("Đại học kinh tế TP.HCM: Phím 3");
                    System.Console.WriteLine("Trường THPT Mạc Đĩnh Chi: Phím 4");
                    System.Console.WriteLine("Trung tâm mua sắm AEON Mall Bình Tân: Phím 5");
                    System.Console.WriteLine("Bệnh viện Hùng Vương: Phím 6");
                    System.Console.WriteLine("Bệnh viện đại học Y dược: Phím 7");
                    ChooseEnd(map7);
                    break;

                default:
                    System.Console.WriteLine("\nYêu cầu bạn nhập không đúng. Chỉ nhập từ 1 - 7");
                    goto Error1;
            }

            System.Console.WriteLine("\nBạn đã tham khảo các thông tin hữu ích về lộ trình đường đi xong!");
        Error2:
            System.Console.WriteLine("Để tiếp tục sử dụng chương trình ấn phím 1, để thoát chương trình ấn phím 2:");
            int choose = Int32.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    goto Begin;
                case 2:
                    System.Console.WriteLine("Bạn đã thoát chương trình");
                    break;
                default:
                    System.Console.WriteLine("\nYêu cầu bạn nhập không đúng vui lòng nhập lại! (1 - 2)");
                    goto Error2;
            }
        }
    }
}
