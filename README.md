# DsVisualization
以Unity2D引擎编写的多功能数据结构可视化应用

# 目录树

Assets
├─Scenes
│  └─Main
├─Scripts
│  ├─Elements 世界中的对象的脚本
│  │   ├─Connection 定义了一个链接两个物体的线
│  │   ├─PointTrace 一个始终跟随鼠标指针的物体
│  │   └─
│  └─Notify 用户交互脚本
│      ├─MouseNotify.cs 鼠标事件
│      └─
├─Appearance
└─Materials

# 文件

## MouseNotify.cs

```cs
public delegate bool MouseClickProc(int type, int button);

//type : 时间的类型 0：有键按下 1：有键松开
//button ：与Unity相同

public event MouseClickProc Clicked;

//鼠标按键事件
```

# 场景Main中的物体

## PointTrace

这是一个始终跟随鼠标指针的物体

## MouseNotify

这个物体中附加了鼠标回调脚本

# 预设的物体

## Connection

这是一根连接两个物体的直线

## PrefabStore

为了防止每当调用一个Prefab对象时，都必须在Inspecor中把Prefab拖进脚本中。我把所有的Prefab文件都储存在一个接口Prefab中，然后直接把这个Prefab布置在场景上。
这样以来，每一个游戏对象都可以通过GameObject.Find("PrefabStore")找到PrefabStore对象，然后就能找到所有的Prefab对象。
我认为这可以降低代码之间的耦合度。毕竟我不想每当创建一个新的脚本，都得满世界去找那狗屁文件。