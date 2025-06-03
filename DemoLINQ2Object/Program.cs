using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int[] arr = { 100, 50, 120, 130, 80, 70, 123, 17, 237 };
/*
 *  Câu 1: Làm LINQ2Object để lọc ra các số chẵn
 */
//Cách Method Syntax
var result = arr.Where(n => n % 2 == 0);
//Cách Query Syntax
var result2 = from n in arr
              where n % 2 == 0
              select n;
Console.WriteLine("Danh sách các số chẵn:");
result2.ToList().ForEach(x => Console.WriteLine(x));
/*
 *  Câu 2: Sắp xếp danh sách tăng dần
 */
var result3 = arr.OrderBy(x => x);
var result4 = from x in arr
              orderby x 
              select x;
Console.WriteLine("\nDanh sách sau khi sắp xếp");
foreach (var item in result3)
{
    Console.WriteLine(item + "\t");
}
/*
 * Câu 3: Sắp xếp danh sách giảm dần
 */
var result5 = arr.OrderByDescending(x => x);
var result6 = from x in arr
              orderby x descending
              select x;

/*
 * Câu 4: Đếm số lượng các số lẻ
 */
int dem = arr.Where(x => x % 2 != 0).Count();