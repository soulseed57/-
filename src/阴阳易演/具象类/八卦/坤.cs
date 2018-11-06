﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 坤 : 八卦
    {
        public 坤()
        {
            先天卦序 = 8;
            后天卦序 = 2;
            先天卦位 = "正北";
            后天卦位 = "西南";
            卦值 = 生成卦值("000");
        }
    }
}
