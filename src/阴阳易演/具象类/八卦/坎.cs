﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 坎 : 八卦
    {
        public 坎()
        {
            先天卦序 = 6;
            后天卦序 = 1;
            先天方位 = "正西";
            后天方位 = "正北";
            卦值 = 生成卦值("010");
        }
    }
}
