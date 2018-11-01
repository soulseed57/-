﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 艮 : 八卦
    {
        public 艮()
        {
            先天卦序 = 7;
            后天卦序 = 8;
            先天方位 = "西北";
            后天方位 = "东北";
            卦值 = 生成卦值("001");
        }
    }
}
