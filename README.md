# 环境

​	Unity2022.3.23f1 & Rider

# 说明

1. 打开Scene/SampleScene场景并运行
2. 点击Run按钮，会自动执行运动和缩放，点击Kill停止，点击Reset恢复初始位置/缩放。
3. 在场景里的Canvas/DoMove物体的ViewDoMove组件上可以设置运动的参数，缓动函数等，DOScale类似。
4. 红色方块使用的是Dotween的接口，白色方块使用的是自己实现接口，观察发现两者运动几乎一致。
