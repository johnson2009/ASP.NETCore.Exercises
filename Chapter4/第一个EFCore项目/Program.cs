using 第一个EFCore项目;
//插入数据

//using TestDbContext ctx = new TestDbContext();
//var b1 = new Book
//{
//    Title = "C#编程",
//    AuthorName = "小明",
//    Price = 99.9,
//    PubTime = DateTime.Now,
//    InsertDateTime = DateTime.Now
//};
//var b2 = new Book
//{
//    Title = "Java编程",
//    AuthorName = "小红",
//    Price = 89.9,
//    PubTime = DateTime.Now,
//    InsertDateTime = DateTime.Now
//};

//var b3 = new Book
//{
//    Title = "Python编程",
//    AuthorName = "小刚",
//    Price = 79.9,
//    PubTime = DateTime.Now,
//    InsertDateTime = DateTime.Now
//};
//var b4 = new Book
//{
//    Title = "Go编程",
//    AuthorName = "小白",
//    Price = 69.9,
//    PubTime = DateTime.Now,
//    InsertDateTime = DateTime.Now
//};
//var b5 = new Book
//{
//    Title = "C++编程",
//    AuthorName = "小黑",
//    Price = 59.9,
//    PubTime = DateTime.Now,
//    InsertDateTime = DateTime.Now
//};
//var b6 = new Book
//{
//    Title = "Blazor编程",
//    AuthorName = "小暗",
//    Price = 99.9,
//    PubTime = DateTime.Now,
//    InsertDateTime = DateTime.Now
//};

//ctx.Books.Add(b1);
//ctx.Books.Add(b2);
//ctx.Books.Add(b3);
//ctx.Books.Add(b4);
//ctx.Books.Add(b5);
//ctx.Books.Add(b6);
//await ctx.SaveChangesAsync();

//查询
using TestDbContext ctx = new TestDbContext();
Console.WriteLine("***所有书***");
foreach(Book book  in ctx.Books)
{
    Console.WriteLine($"书名：{book.Title}，作者：{book.AuthorName}，价格：{book.Price}，出版时间：{book.PubTime}，插入时间：{book.InsertDateTime}");
}
Console.WriteLine("***所有价格高于80元的书***");
IEnumerable<Book> books = ctx.Books.Where(b => b.Price > 80);
foreach (Book book in books)
{
    Console.WriteLine($"书名：{book.Title}，作者：{book.AuthorName}，价格：{book.Price}，出版时间：{book.PubTime}，插入时间：{book.InsertDateTime}");
}

Console.WriteLine("***所有书的平均价格***");
double avgPrice = ctx.Books.Average(b => b.Price);
Console.WriteLine($"平均价格：{avgPrice}");

Console.WriteLine();
Book b1 = ctx.Books.Single(b => b.Title == "C#编程");
Console.WriteLine($"书名：{b1.Title}，作者：{b1.AuthorName}，价格：{b1.Price}，出版时间：{b1.PubTime}，插入时间：{b1.InsertDateTime}");

Book? b2 = ctx.Books.SingleOrDefault(b => b.Id == 9);
if(b2 == null)
{
    Console.WriteLine("没有找到ID为9的书");
}
else
{
    Console.WriteLine($"书名：{b2.Title}，作者：{b2.AuthorName}，价格：{b2.Price}，出版时间：{b2.PubTime}，插入时间：{b2.InsertDateTime}");
}

Console.WriteLine();
Console.WriteLine("***按照价格排序***");
IEnumerable<Book> books2 = ctx.Books.OrderByDescending(b => b.Price);
foreach (Book book in books2)
{
    Console.WriteLine($"书名：{book.Title}，作者：{book.AuthorName}，价格：{book.Price}，出版时间：{book.PubTime}，插入时间：{book.InsertDateTime}");
}

Console.WriteLine();
Console.WriteLine("***按照作者分组***");
var groups = ctx.Books.GroupBy(b => b.AuthorName).Select(g => new {AuthorName = g.Key, BookCount = g.Count(), 
    MaxPrice = g.Max(b => b.Price), TotalPrice = g.Sum(s => s.Price) });
foreach(var group in groups)
{
    Console.WriteLine($"作者：{group.AuthorName}，书籍数量：{group.BookCount}，最高价格：{group.MaxPrice}，总价格：{group.TotalPrice}");
}


//修改数据
//Console.WriteLine("修改数据");
//Book b3 = ctx.Books.First(b => b.Title == "C#编程");
//b3.AuthorName = "小红";
//await ctx.SaveChangesAsync();