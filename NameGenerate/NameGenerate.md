# 名字生成工具（汉语姓名）

这是一个简易的名字生成工具，参照源码中的Main函数使用这个工具。

像下面这样使用

```c# 

NameGenerate N = new NameGenerate();
Console.WriteLine(N.GetRandName());

```

代码中包含两个类， NameManage 和 NameGenerate 。

- NameManage
    
    - 用来存储汉语姓名

- NameGenerate

    - 用来生成汉语姓名
    
读取的文件位于本项目根目录下的 [Resource/Data/NameManage](https://github.com/Liuary/GameBuildTools/tree/master/Resource/Data/NameManage) 文件夹中，用户可以在生成器的构造函数中指定路径。
