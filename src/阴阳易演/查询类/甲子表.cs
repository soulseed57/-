﻿namespace 阴阳易演.查询类
{
    using 容器类;
    using 引用库;

    public static class 甲子表
    {
        static 甲子表()
        {
            甲子数 = 枚举转换类<甲子枚举>.获取所有枚举().Length;
        }
        static readonly int 甲子数;
        public enum 甲子枚举
        {
            甲子, 乙丑, 丙寅, 丁卯, 戊辰, 己巳, 庚午, 辛未, 壬申, 癸酉,
            甲戌, 乙亥, 丙子, 丁丑, 戊寅, 己卯, 庚辰, 辛巳, 壬午, 癸未,
            甲申, 乙酉, 丙戌, 丁亥, 戊子, 己丑, 庚寅, 辛卯, 壬辰, 癸巳,
            甲午, 乙未, 丙申, 丁酉, 戊戌, 己亥, 庚子, 辛丑, 壬寅, 癸卯,
            甲辰, 乙巳, 丙午, 丁未, 戊申, 己酉, 庚戌, 辛亥, 壬子, 癸丑,
            甲寅, 乙卯, 丙辰, 丁巳, 戊午, 己未, 庚申, 辛酉, 壬戌, 癸亥
        }

        public static 甲子 甲子查询(string 名)
        {
            var 枚 = 枚举转换类<甲子枚举>.获取枚举(名);
            return 甲子查询(枚);
        }
        public static 甲子 甲子查询(int 序)
        {
            序 = 枚举转换类<甲子枚举>.序数取余(序, 甲子数);
            var 枚 = 枚举转换类<甲子枚举>.获取枚举(序);
            return 甲子查询(枚);
        }
        public static 甲子 甲子查询(甲子枚举 枚)
        {
            return new 甲子(枚);
        }

    }
}
