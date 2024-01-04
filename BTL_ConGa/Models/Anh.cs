using System;
using System.Collections.Generic;

namespace BTL_ConGa.Models;

public partial class Anh
{
    public string MaAnh { get; set; } = null!;

    public string TenAnh { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public string MaMonAn { get; set; } = null!;

    public virtual MonAn MaMonAnNavigation { get; set; } = null!;
}
