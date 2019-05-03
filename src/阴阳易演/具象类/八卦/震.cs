﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;
    using 枚举类;
    using 计算类;

    public class 震 : 八卦
    {
        public 震()
        {
            先天数 = 4;
            后天数 = 3;
            卦位 = 八方方位.东北;
            方位 = 八方方位.正东;
            爻值 = 八卦计算.生成爻值("100");
            四象 = 四象.少阴;
            人象 = "长男";
            卦象 = "雷";
        }
    }
}
