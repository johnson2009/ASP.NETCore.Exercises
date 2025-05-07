using EFCore原理;
using Microsoft.EntityFrameworkCore;

//IEnumberable 版查询
/* using var ctx = new TestDbContext();
IEnumerable<Book> books = ctx.Books;
foreach (var b in books.Where(b => b.Price > 1.1))
{
	Console.WriteLine($"Id={b.Id},Title={b.Title}");
} */

// 没有遍历的查询
/* using var ctx = new TestDbContext();
IQueryable<Book> books = ctx.Books.Where(b => b.Price > 1.1);
Console.WriteLine(books);
 */
//遍历查询
/* using var ctx = new TestDbContext();
Console.WriteLine("1. Where之前");
IQueryable<Book> books = ctx.Books.Where(b => b.Price > 1.1);
Console.WriteLine("2. Where之后, 遍历IQueryable之前");
foreach (var b in books)
{
    Console.WriteLine($"Id={b.Id},Title={b.Title}");
}
Console.WriteLine("3. 遍历IQueryable之后, 结束"); // 结束时会执行SQL语句
 */

//拼接复杂的查询条件
/* QueryBooks("编程", true, true, 1000);

void QueryBooks(string searchWords, bool searchAll, bool orderByPrice, double upperPrice)
{
    using TestDbContext ctx = new TestDbContext();
    IQueryable<Book> books = ctx.Books.Where(b => b.Price < upperPrice);
    if(searchAll)
    {
        books = books.Where(b => b.Title.Contains(searchWords) || b.AuthorName.Contains(searchWords));
    }
    else
    {
        books = books.Where(b => b.Title.Contains(searchWords));
    }
    if(orderByPrice)
    {
        books = books.OrderBy(b => b.Price);
    }
    foreach (var b in books)
    {
        Console.WriteLine($"Id={b.Id},Title={b.Title}");
    }
} */

//IQueryable的复用
/* using var ctx = new TestDbContext();
var books = ctx.Books.Where(b => b.Price >= 8);
Console.WriteLine(books.Count());
Console.WriteLine(books.Max(b => b.Price));
foreach(Book b in books.Where(b => b.PubTime.Year > 2000))
{
    Console.WriteLine(b.Title);
}
 */

//分页查询
//添加一些数据
/* TestDbContext ctx = new TestDbContext();
List<Book> books = new List<Book>(){
       new Book(){Title="C#编程", AuthorName="Amanda", Price= 10, PubTime = DateTime.Now},
       new Book(){Title="Java编程", AuthorName="Amanda", Price= 20, PubTime = DateTime.Now},
       new Book(){Title="Python编程", AuthorName="Amanda", Price= 30, PubTime = DateTime.Now},
       new Book(){Title="Go编程", AuthorName="Amanda", Price= 40, PubTime = DateTime.Now},
       new Book(){Title="C++编程", AuthorName="Amanda", Price= 50, PubTime = DateTime.Now},
       new Book(){Title="C编程", AuthorName="Amanda", Price= 60, PubTime = DateTime.Now},
       new Book(){Title="JavaScript编程", AuthorName="Amanda", Price= 70, PubTime = DateTime.Now},
       new Book(){Title="PHP编程", AuthorName="Amanda", Price= 80, PubTime = DateTime.Now},
       new Book(){Title="Ruby编程", AuthorName="Amanda", Price= 90, PubTime = DateTime.Now},
       new Book(){Title="Swift编程", AuthorName="Amanda", Price= 100, PubTime = DateTime.Now},
       new Book(){Title="Kotlin编程", AuthorName="Amanda", Price= 110, PubTime = DateTime.Now},
       new Book(){Title="R编程", AuthorName="Amanda", Price= 120, PubTime = DateTime.Now},
       new Book(){Title="Dart编程", AuthorName="Amanda", Price= 130, PubTime = DateTime.Now},
       new Book(){Title="Go编程", AuthorName="Amanda", Price= 140, PubTime = DateTime.Now},
       new Book(){Title="C#编程", AuthorName="Amanda", Price= 150, PubTime = DateTime.Now}
};
ctx.Books.AddRange(books);
await ctx.SaveChangesAsync();
Console.WriteLine("数据添加完成");
*/
/* 
OutputPage(1, 5);
OutputPage(2, 5);

void OutputPage(int pageIndex, int pageSize)
 {
    using var ctx = new TestDbContext();
    IQueryable<Book> books = ctx.Books.Where(b => !b.Title.Contains("C"));
    long count = books.LongCount();
    long pageCount = (long)Math.Ceiling(count * 1.0/ pageSize);
    Console.WriteLine($"总记录数={count}, 总页数={pageCount}");
    var pagedBooks = books.Skip((pageIndex -1) * pageSize).Take(pageSize);
    foreach (var b in pagedBooks)
    {
        Console.WriteLine($"Id={b.Id},Title={b.Title}");
    }
    Console.WriteLine($"第{pageIndex}页数据输出完毕");
 } */

 //有错误的返回IQueryable查询结果

/* foreach (var b in QueryBooks())
{
	Console.WriteLine(b.Title);
}
IQueryable<Book> QueryBooks()
{
	using TestDbContext ctx = new TestDbContext();
	return ctx.Books.Where(b => b.Id > 5);
} */

//正确的返回查询结果
/* foreach (var b in QueryBooks())
{
	Console.WriteLine(b.Title);
}
IEnumerable<Book> QueryBooks()
{
	using TestDbContext ctx = new TestDbContext();
	return ctx.Books.Where(b => b.Id > 5).ToArray();
} */

//执行原生SQL非查询语句
/*using var ctx = new TestDbContext();
Console.WriteLine("请输入最低价格");
double price = double.Parse(Console.ReadLine()!);
Console.WriteLine("请输入姓名");
string name = Console.ReadLine()!;
int rows = await ctx.Database.ExecuteSqlInterpolatedAsync(@$"
    insert into T_Books(Title, AuthorName, Price, PubTime)
    select Title, AuthorName, Price, PubTime from T_Books where Price > {price} and AuthorName = {name}");
Console.WriteLine($"插入了{rows}行数据"); */

//执行实体类SQL查询语句
/* using TestDbContext ctx = new TestDbContext();
Console.WriteLine("请输入年份");
int year = int.Parse(Console.ReadLine());
IQueryable<Book> books = ctx.Books.FromSqlInterpolated(@$"select * from T_Books
		where YEAR(T_Books.PubTime)>{year} order by RAND()");
foreach (Book b in books.Skip(3).Take(5))
{
	Console.WriteLine(b.Title);
} */

using TestDbContext ctx = new TestDbContext();

Book b1 = new Book { Id = 10 };
b1.Title = "yzk";
var entry1 = ctx.Entry(b1);
//entry1.Property("Title").IsModified = true;
Console.WriteLine(entry1.DebugView.LongView);
ctx.SaveChanges();
// Book b1 = new Book { Id = 28 };
// ctx.Entry(b1).State = EntityState.Deleted;
// ctx.SaveChanges();

