using System;
using System.Text;

namespace PKT.Pinyin.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] maxims = new string[]{
        "事常与人违，事总在人为",
        "骏马是跑出来的，强兵是打出来的",
        "驾驭命运的舵是奋斗。不抱有一丝幻想，不放弃一点机会，不停止一日努力。 ",
        "如果惧怕前面跌宕的山岩，生命就永远只能是死水一潭",
        "懦弱的人只会裹足不前，莽撞的人只能引为烧身，只有真正勇敢的人才能所向披靡"
      };

            string[] medicines = new string[] {
        "聚维酮碘溶液",
        "开塞露",
        "炉甘石洗剂",
        "苯扎氯铵贴",
        "鱼石脂软膏",
        "莫匹罗星软膏",
        "红霉素软膏",
        "氢化可的松软膏",
        "曲安奈德软膏",
        "丁苯羟酸乳膏",
        "双氯芬酸二乙胺乳膏",
        "冻疮膏",
        "克霉唑软膏",
        "特比奈芬软膏",
        "酞丁安软膏",
        "咪康唑软膏、栓剂",
        "甲硝唑栓",
        "复方莪术油栓quan"
      };

            Console.WriteLine("UTF8句子拼音：");
            foreach (string s in maxims)
            {
                Console.WriteLine("汉字：{0}\n拼音：{1}\n", s, PKT.NPinyin.Pinyin.GetInitials(s));
            }

            //nuget System.Text.Encoding.CodePages
            //注册支持获取GB2312/GBK编码
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            Encoding gb2312 = Encoding.GetEncoding("GB2312");
            Console.WriteLine("GB2312拼音简码：");
            foreach (string m in medicines)
            {
                string s = PKT.NPinyin.Pinyin.ConvertEncoding(m, Encoding.UTF8, gb2312);
                Console.WriteLine("药品：{0}\n简码：{1}\n", s, PKT.NPinyin.Pinyin.GetInitials(s, gb2312));
            }

            Console.WriteLine("全拼：");
            foreach (string m in medicines)
            {
                Console.WriteLine("药品：{0}\n全码：{1}\n", m, PKT.NPinyin.Pinyin.GetPinyin(m));
            }

            Console.ReadKey();
        }
    }
}
