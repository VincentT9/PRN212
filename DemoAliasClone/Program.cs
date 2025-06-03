using System.Text;
using DemoAliasClone;

Console.OutputEncoding = Encoding.UTF8;

Customer c1 = new Customer();
c1.Id = 1;
c1.Name = "Trần Thị Tèo";

Customer c2 = new Customer();
c1.Id = 2;
c1.Name = "Nguyễn Văn Tẹt";

c1 = c2;
// c1 trỏ tới vùng nhớ mà c2 đang quản lý
// chứ không phải c1 bằng c2 
// => Lúc này xảy ra 2 tình huống 
// (1) Ô nhớ alpha mà c1 quản lý lúc nãy bị trống 
// không còn đối tượng nào tham gia quản lý nữa 
// ==> Hệ điều hành sẽ thu hồi ô nhớ Alpha này
// gọi là cơ chế gom rác tự động: Automatic Garbage Collection
// Ta không thể nào lấy được giá trị tại ô nhớ này nữa 
// (2) Lúc này ô nhớ Beta sẽ có 2 đối tượng tham gia quản lý
// - đối tượng ban đầu là c2
// - bây giờ có thêm đối tượng c1 quảng lý
// Trường hợp 1 ô nhớ từ từ 2 đối tượng trở lên tham gia quản lý
// nó được gọi là Alias: 
// -> Bất kỳ 1 đối tựng nào đổi giá trị tại ô nhớ Beta
// --> thì các đối tựong còn lại đều bị ảnh hưởng

c1.Name = "Hồ Đồ";
//Thì lúc này c2 cũng bị đổi tên thành "Hồ Đồ"
// Vì c1 và c2 đang quản lý 1 ô nhớ 
Console.WriteLine("Tên của c2 = " + c2.Name);

Customer c3 = new Customer();
Customer c4 = c3;
c3 = c1;
// Không có thu hồi ô nhớ của c3 đang quản lý

Product p1 = new Product { Id = 1, Name = "P1", Price = 10, Quantity = 20 };
Product p2 = new Product { Id = 2, Name = "P2", Price = 15, Quantity = 22 };
p1 = p2;
Console.WriteLine("----Thông tin của P1----");
Console.WriteLine(p1);
Console.WriteLine("----Thông tin của P2----");
Console.WriteLine(p2);

p2.Name = "Thuốc trị hôi nách";
p2.Quantity = 50;
p2.Price = 100;

Console.WriteLine("----Thông tin của P1----");
Console.WriteLine(p1);

Product p3 = new Product { Id = 3, Name = "P3", Price = 15, Quantity = 22 };

Product p4 = new Product { Id = 4, Name = "P4", Price = 15, Quantity = 22 };

Product p5 = p3;
p3 = p4;
//HĐH có thu hồi ô nhớ đã cấp phát cho p3 quản lý trước đó hay không vì sao? 
// Không vì p5 đang quản lý p3 
// nếu bổ sung:
p5 = p3;
// thì có thu hồi ô nhớ đã cấp phát cho p3hay không vì sao ?
// Có vì trước đó p3 đã di chuyển qua p4, sau đó p5 trỏ qua p3 tức là 
// đang trỏ qua tới p4 vậy nên p3 được thu hồi

Product p6 = p4.Clone();
//HĐH sẽ sao chép toàn bộ dữ liệu mà p4 đang quản lý qua 1 ô nhớ mới
//và giao cho p6 quản lý ô nhớ mới này:
//p4 và p6 quan lý 2 ô nhớ khác nhau hoàn toàn, nhưng có giá trị giống nhau
//==> p6 dổi k ảnh hưởng gì đến p4, và ngược lại
p4.Name = "Thuốc trị xàm";
Console.WriteLine("----Thông tin của P4----");
Console.WriteLine(p4);
Console.WriteLine("----Thông tin của P6----");
Console.WriteLine(p6);
