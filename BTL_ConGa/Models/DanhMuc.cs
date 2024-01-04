using System;
using System.Collections.Generic;

namespace BTL_ConGa.Models;

public partial class DanhMuc
{
    public string MaDanhMuc { get; set; } = null!;

    public string TenDanhMuc { get; set; } = null!;

    public virtual ICollection<MonAn> MonAns { get; } = new List<MonAn>();
}
