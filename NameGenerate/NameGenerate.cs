using System;
using System.IO;
using System.Text;

namespace NameGenerate
{

    // 姓名管理器
    class NameManage
    {
        // 姓
        private String _Surname;

        // 名
        private String _Name;

        // 姓的公开访问
        public String Surname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }

        // 名的公开访问
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        // 构造函数
        public NameManage()
        {
            this._Surname = "";
            this._Name = "";
        }

        public NameManage(String Surname, String Name)
        {
            this._Surname = Surname;
            this._Name = Name;
        }

        public NameManage(NameManage OtherName)
        {
            this._Surname = OtherName.Surname;
            this._Name = OtherName.Name;
        }

        // 转成字符串
        public override String ToString()
        {
            return _Surname + _Name;
        }

    }

    // 姓名生成器
    class NameGenerate
    {
        // 随机数生成工具
        Random RandTool;

        // 存储文档中的姓和名
        String[][] NameReadArray;

        // 构造函数，可以调整文档的路径
        public NameGenerate(
            String SurnamePath = "Resource/Data/NameManage/Surname.txt",
            String NamePath = "Resource/Data/NameManage/Name.txt")
        {
            // 初始化随机数生成器
            RandTool = new Random();

            // 初始化文档存储数组
            NameReadArray = new String[2][];

           // 存储访问的路径
           String[] FilePathArray =
            {
                SurnamePath,
                NamePath
            };

            // 对所有路径读取
            for (int i = 0; i < 2; i++)
            {
                // 读取文件的工具
                StreamReader FileRead = new StreamReader(FilePathArray[i], Encoding.Default);
                String line;
                String Context = "";
                while ((line = FileRead.ReadLine()) != null)
                {
                    Context += line;
                }
                NameReadArray[i] = Context.Split(" ");
            }

        }

        // 获取一个随机的姓名, 参数表示名字的长度（名字长度不是姓名的长度）
        public NameManage GetRandName(int NameLength = -1)
        {
            if (NameLength.Equals(-1))
            {
                NameLength = RandTool.Next(1, 3);
            }

            switch (NameLength)
            {
                // 两个字
                case 1:
                    {
                        return new NameManage(
                            NameReadArray[0][RandTool.Next(0, NameReadArray[0].Length)],
                            NameReadArray[1][RandTool.Next(0, NameReadArray[1].Length)]);
                    }
                // 三个字
                case 2:
                    {
                        return new NameManage(
                            NameReadArray[0][RandTool.Next(0, NameReadArray[0].Length)],
                            NameReadArray[1][RandTool.Next(0, NameReadArray[1].Length)] +
                            NameReadArray[1][RandTool.Next(0, NameReadArray[1].Length)]);
                    }
                default:
                    {
                        return new NameManage("张", "三");
                    }
            }

        }

        //static void Main(string[] args)
        //{

        //    NameGenerate N = new NameGenerate();

        //    Console.WriteLine(N.GetRandName());
        //}
    }
}
