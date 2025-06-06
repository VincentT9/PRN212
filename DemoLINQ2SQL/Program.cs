using System.Text;
using DemoLINQ2SQL;

Console.OutputEncoding = Encoding.UTF8;
// khái báo chuỗi kết nối tới CSDL

string connectionString =
    @"server=DESKTOP-TUN9PP6\SQLEXPRESS;database=MyStore;uid=sa;pwd=12345";
MyStoreDataContext context = new MyStoreDataContext(connectionString);

//Câu 1: Truy vấn toàn bộ danh mục 
var dsdm = context.Categories.ToList();
Console.WriteLine("---Danh sách danh mục---");
foreach (var d in dsdm)
{
    Console.WriteLine(d.CategoryID +"\t" + d.CategoryName);
}

//Câu 2: Lấy thông tin chi tiết danh mục khi biết mã
int madm = 7;
Category cate = context.Categories
    .FirstOrDefault(c => c.CategoryID == madm);
if (cate == null)
{
    Console.WriteLine("Không tìm thấy danh mục có mã = " + madm);
}
else
{
    Console.WriteLine("Tìm thấy sản phẩm có mã = " + madm);
    Console.WriteLine(cate.CategoryID + "\t" + cate.CategoryName);
}

// Câu 3: Dùng Query Syntax để truy vấn toàn bộ sản phẩm
var dssp = from p in context.Products
           select p;
Console.WriteLine("---Danh sách sản phẩm---");
foreach (var p in dssp)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}

// Câu 4: Dùng Query Syntax và Anonymous Type để lọc ra 
// các sản phẩm nhưng chỉ lấy mã sản phẩm và đơn giá
// đồng thời sắp xếp giảm dần
var dssp4 = from p in context.Products
            orderby p.UnitPrice descending
            select new { 
                p.ProductID,
                p.UnitPrice
            };
Console.WriteLine("---Danh sách sản phẩm theo câu 4---");
foreach (var p in dssp4)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice);
}

// Câu 5: Sửa câu 4 theo extention method (Method Syntax)
var dssp5 = context.Products
    .OrderByDescending(p => p.UnitPrice)
    .Select(p => new
    {
        p.ProductID,
        p.UnitPrice
    });
Console.WriteLine("---Danh sách sản phẩm theo câu 5---");
foreach (var p in dssp5)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice);
}

// Câu 6: Lọc ra top 3 sản phẩm có giá lớn nhất hệ thống
var dssp6 = context.Products
    .OrderByDescending(p => p.UnitPrice)
    .Take(3);
Console.WriteLine("---Danh sách sản phẩm theo câu 6---");
foreach (var p in dssp6)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}

// Câu 7: Sửa tên danh mục khi biết mã
int madm_edit = 6;
var cate_edit = context.Categories
    .FirstOrDefault(c => c.CategoryID == madm_edit);
if (cate_edit != null)
{
    cate_edit.CategoryName = "Hàng trôi nổi";
    context.SubmitChanges();//Xác nhận lưu thay đổi
}

// Câu 8: Xóa danh mục khi biết mã
int madm_xoa = 4;
var cate_xoa = context.Categories
    .FirstOrDefault(c => c.CategoryID == madm_xoa);
if (cate_xoa != null)
{
    context.Categories.DeleteOnSubmit(cate_xoa);
    context.SubmitChanges();//Xác nhận xóa dữ liệu
}

// Câu 9: Xóa các danh mục nếu không có bất kỳ sản phẩm nào
// Lưu ý: là xóa cùng 1 lúc nhiều danh mục, mà các danh mục này
// không có chứa bất kỳ 1 sản phẩm nào
var dsdm_empty_product = context.Categories
    .Where(c => c.Products.Count() == 0)
    .ToList();

context.Categories.DeleteAllOnSubmit(dsdm_empty_product);
context.SubmitChanges();//Xác nhận xóa dữ liệu

// Câu 10: Thêm mới 1 danh mục
var c_new = new Category();
c_new.CategoryName = "Hàng lậu từ Trung Quốc";
context.Categories.InsertOnSubmit(c_new);   
context.SubmitChanges();//Xác nhận thêm mới dữ liệu

// Câu 11: Thêm mới nhiều danh mục
List<Category> list = new List<Category>();
list.Add(new Category { CategoryName = "Hàng Gia dụng" });
list.Add(new Category { CategoryName = "Hàng Điện tử" });
list.Add(new Category { CategoryName = "Hàng Phụ kiện" });
context.Categories.InsertAllOnSubmit(list);
context.SubmitChanges();//Xác nhận thêm mới dữ liệu