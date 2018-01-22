using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace theSite.Models
{
    public class RichTextEditorModel
    {
        public string Content { set; get; }
    }

    public class Article
    {
        [Display(Name = "文章")]
        public int ArticleID { get; set; }

        [Display(Name = "栏目类别")]
        public int CategoryID { get; set; }

        [Display(Name = "标题")]
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "正文")]
        [DataType(DataType.MultilineText)]   //如在视图中使用强类类型的辅助方法@Html.EditorFor(model =>model),则此字段将被渲染成<textarea>文本域标签。
        public string Content { get; set; }

        [Display(Name = "作者")]
        [StringLength(20)]
        public string AuthorName { get; set; }


        [Display(Name = "发表时间")]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime PostTime { get; set; }

        // public virtual Category Category { get; set; }



        //如不直接使用数据库上下文对象，使用仓储代码如下。
        /*
        public class ArticleService : BaseService<Article>
        {
            public ArticleService(DbContext dbContext) : base(dbContext) { }
        }
        */
    }
}