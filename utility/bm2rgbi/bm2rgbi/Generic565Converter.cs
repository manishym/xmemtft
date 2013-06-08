﻿using System.Drawing;
using System.IO;
using System;

namespace bm2rgbi {
  
  /// <summary>
  /// generic converter for 565 format 64K colours
  /// Format: RRRRRGGGGGGBBBBB
  /// </summary>
  
  public class Generic565Converter {

    /// <summary>
    /// Convert to 565 format
    /// </summary>

    public void convert(Bitmap bm,FileStream fs) {

      int x,y,value,r,g,b;
      Color c;

      for(y=0;y<bm.Height;y++) {

        for(x=0;x<bm.Width;x++) {

          c=bm.GetPixel(x,y);

          // convert to 565

          r=c.R>>3;
          g=c.G>>2;
          b=c.B>>3;
  
          value=r<<11 | g<<5 | b;

          // little-endian output

          fs.WriteByte(Convert.ToByte(value & 0xFF));
          fs.WriteByte(Convert.ToByte(value >> 8));
        }
      }
    }
  }
}
