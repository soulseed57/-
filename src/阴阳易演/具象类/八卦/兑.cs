﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 兑 : 八卦
    {
        public 兑()
        {
            序数 = 2;
            本数 = 7;
            方位 = "正西";
            卦值 = 生成卦值("110");
            四象 = 四象.太阳;
        }
    }
}
