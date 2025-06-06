using System.Text;
using Lucy_SalesDataManagement;

Console.OutputEncoding = Encoding.UTF8;

string connectionString =
    @"server=DESKTOP-TUN9PP6\SQLEXPRESS;database=Lucy_SalesData;uid=sa;pwd=12345";
Lucy_SalesDataDataContext context = new Lucy_SalesDataDataContext(connectionString);

// Câu 1: Lọc ra toàn bộ khách hàng
var dskh = context.Customers.ToList();
Console.WriteLine("---Danh sách khách hàng---");
foreach (var d in dskh)
{
    Console.WriteLine(d.CustomerID + "\t" + d.ContactName);
}

// Câu 2: Tìm chi tiết thông tin khách hàng
// khi biết mã khách hàng
int mkh = 10;
var cust = context.Customers
    .FirstOrDefault(c => c.CustomerID == mkh);
if (cust != null)
{
    Console.WriteLine("---Chi tiết thông tin khách hàng = " + mkh);
    Console.WriteLine(cust.CustomerID + "\t" + cust.ContactName);
}    

// Câu 3: Từ kết quả của câu 2, lọc ra danh sách các hóa đơn của khách hàng
// Các cột dữ liệu gồm: mã hóa đơn + ngày hóa đơn
if (cust != null)
{
    var dshd = cust.Orders.Select(o => new
    {
        o.OrderID,
        o.OrderDate
    });
    var dshd2 = from o in cust.Orders
                     select new
                     {
                         o.OrderID,
                         o.OrderDate
                     };
    Console.WriteLine("Danh sách hóa đơn của khách hàng");
    foreach (var o in dshd)
    {
        Console.WriteLine(o.OrderID + "\t" + o.OrderDate.ToString("dd/MM/yyyy"));
    }
}

// Câu 4: Từ kết quả của câu 3
// Bổ sung thêm cột trị giá hóa đơn hơn cho mỗi hóa đơn
if (cust != null)
{
    var dshd3 = cust.Orders
        .Select(o => new
    {
        o.OrderID,
        o.OrderDate,
        Total = o.Order_Details
                .Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount))
    });
    Console.WriteLine("Danh sách hóa đơn của khách hàng");
    foreach (var o in dshd3)
    {
        Console.WriteLine(o.OrderID + "\t" + o.OrderDate.ToString("dd/MM/yyyy") + "\t" + o.Total);
    }
}