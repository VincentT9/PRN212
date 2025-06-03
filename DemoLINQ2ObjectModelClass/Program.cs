using System.Text;
using DemoLINQ2ObjectModelClass;

Console.OutputEncoding = Encoding.UTF8;

ListProduct lp = new ListProduct();
lp.gen_products();

/*
 * Câu 1: Lọc ra các sản phẩm có giá từ a đến b
 */
var result = lp.FilterProductsByPrice2(100, 200);
Console.WriteLine("Các sản phẩm có giá từ 100 đến 200");
result.ForEach(x => Console.WriteLine(x));

/*
 * Câu 2: Sắp xếp sản phẩm theo đơn giá tăng dần
 */
var result2 = lp.OrderByPriceAcsending();
Console.WriteLine("Các sản phẩm sau khi sắp xếp giá tăng dần: ");
result2.ForEach(x => Console.WriteLine(x));

/*
 * Câu 3: Sắp xếp sản phẩm theo đơn giá giảm dần
 */
var result3 = lp.OrderByPriceDescending();
Console.WriteLine("Các sản phẩm sau khi sắp xếp giá tăng dần: ");
result3.ForEach(x => Console.WriteLine(x));

/*
 * Câu 4: Tính tổng giá trị các sản phẩm trong kho hàng
 */
Console.WriteLine("Tổng giá trị các sản phẩm trong kho hàng: " + lp.SumOfValue());

/*
 * Câu 5: Tìm chi tiết sản phẩm khi biết mã sản phẩm
 */
Product p = lp.SearchProductDetail(3);
if (p != null)
{
    Console.WriteLine("Tìm thấy sản phẩm, có thông tin chi tiết: ");
    Console.WriteLine(p);
}
else
{
    Console.WriteLine("Không tìm thấy sản phẩm");
}

/*
 * Câu 6: Viết hàm lọc ra top N sản phẩm có giá trị lớn nhất
 */
var result4 = lp.GetTopProduct(3);
Console.WriteLine("Top 3 sản phẩm có tổng giá trị lớn nhất: ");
result4.ForEach(x => Console.WriteLine(x+ "=>" + x.Price*x.Quantity));