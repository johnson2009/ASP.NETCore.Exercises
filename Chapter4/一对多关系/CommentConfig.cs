using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 一对多关系
{
    public class CommentConfig: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("T_Comments");            
            builder.HasOne(e => e.Article).WithMany(e => e.Comments).HasForeignKey(e => e.ArticleId);
            builder.Property(e => e.Message).IsRequired().IsUnicode();
        }
    }
}
