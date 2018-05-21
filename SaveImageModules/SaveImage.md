#SaveImage.Dll 使用说明 

-------------------
　　**SaveImage.dll**用于被保存图片。可以将Bitmap的图片以.bmp或.jpg格式保存在本地磁盘上。在 **SaveImage.dll** 中主要包含四个实现类： **[CSaveImage](#Class1)** 、 **[SaveImageDecorator](#Class2)** 、 **[CSafeSaveImage](#Class3)** 、 **[SafeSaveImageHelper](#Class4)** 和两个用户控件: **[SaveImageCtrl](#UserControl1)** 、 **[SafeSaveImageCtrl](#UserControl2)** 以及一个接口： **[ISaveImage](#Interface1)** 。


## <h2 id = "Class1">CSaveImage</h2>

###`描述`
　　**CSaveImage** 类实现了最基础的保存图片功能，可以自动创建文件夹、检查图片名称的合法性等，该类实现了 **ISaveImage** 接口。  
**NameSpace:** SaveImage  
**Assembly:** SaveImage.Dll	 

###`构造`  

1、 **`public CSaveImage(string configFilePath)`**  :configFilePath是保存图片配置文件的路径。  
2、**`public CSaveImage(string configFilepath,string savePath, bool isSave, string sectionName)`** : 　configFIlePath是保存图片配置文件的路径，savePath是保存图片的路径，isSave是否保存图片，　　sectionName保存图片的配置信息在ini文件中的‘节’名称。

 
###`属性`
    
 |名称|类型|描述|备注|
 |--------|:-----:|:----:|:-----:|
 |SectionName|string|获取或设置保存图片的配置信息在ini文件中的节名称|
 |ConfigFilePath|string|获取保存图片配置文件路径|
 |SavePath|string|获取或设置保存图片的路径|
 |SaveImageRootDictroy|string|获取保存图片的根目录|
 |SaveType|[SaveImageType](#SaveType)|获取或设置保存图片的格式|
 |IsSaveImage|bool|获取或设置是否保存图片，默认保存|
 |ImageName|string|获取保存的图像的名称|
 |IsAddTimeToImageName|bool|获取或设置是否在图像名称后面自动添加时间后缀|
 |ImageQueueMaxCount|int|获取或设置保存图像队列最大容量，默认20|  
    
   
  
###`方法`　　

|方法名|返回类型|形参列表|描述|
|------|:------:|:------:|:-----|
|Save|string|1、image(Bitmap):输入图像；２、imageName(string):图像名称。|保存图像，并返回图像的完整路径

###`事件`　

|事件名|类型|描述|
|------|:------:|:------:|
|SaveCompleteEvent|SaveImasgeCompleteEventHandle|保存图片完成事件，保存图片完成后引发该事件，可以通过该事件获取保存图像完成时间、错误信息、图像路径等|
|SavePathChangedEvent|SavePathChangedEventHandle|保存图像路径改变事件，可以获取改变后的保存图片的路径|
|RootDirectoryChangedEvent|SaveImageRootDirectoryChangedEventHandle|保存图片根目录改变事件，可获取当前保存图片路径的根目录|


## <h2 id = "Class2">SaveImageDecorator</h2>

###`描述`
　　**SaveImageDecorator** 是类SaveImage的装饰者，由它来负者装饰SaveImage以达到动态扩展SaveImage类的功能的目的。由于 **SaveImageDecorator** 与SaveImage一样都实现了ISaveImage接口，所以内部实现几乎与SaveImage类相同，所以就不做过多介绍了。



## <h2 id = "Class3">CSafeSaveImage</h2>  

###`描述`
　　**CSafeSaveImage**类继承了SaveImageDecorator，扩展了SaveImage类的功能，这里主要是添加自动删除图片的功能。目前有两种删除图片的模式，一是按照“时间容量”来删除，二是按照“容量”来删除。“时间容量”：在保存图片之前会检查存储图片路径信息的数据库中有没有大于设定日期的图片信息，如果有读取路径信息并执行删除图片功能，删除完后再去检查磁盘可用容量是不是小于当前设定容量，如果是去读取数据库中最早的一条图片信息并删除对应的图片。“容量”：在保存图片之前检查磁盘可用容量看是否低于设定容量，如果是删除数据库中最早的那种图片。  
　　**备注：** 由于该类使用到了数据库，在使用该类时**必须**将SaveImageDB.mdf文件拷贝到与.exe文件相同的目录下，并且需要引用**“DataBaseComponent.dll”** 文件 。

###`构造`

1、**`public CSafeSaveImage( ref CSaveImage _saveImage)`** ：_saveImage具体的CSaveImage对象  

###`属性`  

|名称|类型|描述|备注|
|-----|:------:|:-----:|:-----:|
|DeleteMode|AutoDeleteImageModeEnum|获取或设置删除图片的模式，NONE=0：不删除图片；TIMEANDSPACE=1：按时间容量删除图片；SPACE=2：按容量删除|
|ImageLifeSpan|int|获取或设置图片在磁盘上的保存时间（单位：天），最小1天|
|DiskAllowsMinCapacity|double|磁盘最小允许容量（单位：GB），最小0.5GB|
|IsDBLinked|bool|获取数据库是否连接|由于使用到了数据库，在类实例化后最好检查一下数据库是否连接|

###`方法`

|方法名|返回类型|形参列表|描述|
|------|:------:|:------:|:-----|
|SaveImage|string|1、image(Bitmap):输入图像；２、imageName(string):图像名称。|保存图像，并返回图像的完整路径|

###`事件`
|事件名|类型|描述|
|------|:------:|:------:|
|LogEvent|LogInfoEventHandle|Log事件|



## <h2 id = "Class4">SafeSaveImageHelper</h2>  

###`描述`  
　　**SafeSaveImageHelper**是CSaveImage和CSafeSaveImage类的包装。CSafeSaveImage是CSaveImage的一个具体装饰者，扩展了CSaveImage的功能，实际上不需要SafeSaveImageHelper类就可以达到自动删图功能了，但是考虑到并不是所有使用者都了解“装饰者模式”，所以推出了一个包装类，即SafeSaveImageHelper。  
　　**SafeSaveImageHelper**中的构造函数与CSaveImage是一样的，其中的属性是CSaveImage和CSafeSaveImage的集合，在此就不做过多描述了。



## <h2 id = "UserControl1">SaveImageCtrl</h2>  

　　**SaveImageCtrl**控件是CSaveImage类的专用UI控件，如下图所示。

![](https://i.imgur.com/UlQm6eb.png)

###`属性`  

 |名称|类型|描述|
 |-----|:-----:|:----:|
 |Subject|CSaveImage|获取或设置控件的控制实例|  


## <h2 id = "UserControl2">SafeSaveImageCtrl</h2>  

　　**SafeSaveImageCtrl**控件是SafeSaveImageHelper类的专用UI控件，如下图所示。  

![](https://i.imgur.com/WASg2nw.png)

###`属性`  

 |名称|类型|描述|
 |-----|:-----:|:----:|
 |Subject|SafeSaveImageHelper|获取或设置控件的控制实例|