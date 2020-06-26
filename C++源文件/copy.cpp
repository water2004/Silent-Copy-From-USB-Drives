#include<iostream>
#include<cstdlib>
#include<string>
#include<set>
#include<cstring>
#include<sstream>
#include<Windows.h>
#include<fstream>
#include <direct.h>  
#include <stdio.h> 

using namespace std;
set<string> pan;
set<string> cp;
string from, name, tmp, to, mx, mn, maxage, minage, maxlad, minlad, r, w, lev, mt, lg, wait,leng;
int sleep;
int diskCount;
bool new_floder; 
string days[8]={"日","一","二","三","四","五","六","日"}; 
void trimString(string & str )
{
    int s = str.find_first_not_of(" ");
    int e = str.find_last_not_of(" ");
    if(s==-1||e==-1)
    {
    	str="";
    	return;
	}
    str = str.substr(s,e-s+1);
}
void check()
{
	while(1)//逐个检查新盘符 
	{
		int dc2=GetLogicalDrives();
		if(dc2>diskCount) break;//排除拔出设备的干扰 
		if(dc2<diskCount) 
		{
			diskCount=dc2; 
			pan.clear();
			DWORD dwLen = GetLogicalDriveStrings(0,NULL);//获取系统盘符字符串长度
			char *pszDriver = new char[dwLen];//构建字符数组
			GetLogicalDriveStrings(dwLen,pszDriver);//获取系统盘符字符串
			char* pDriver = pszDriver;
			string s;
			while(*pDriver != '\0')
			{
				s=pDriver;
				pan.insert(s); 
				pDriver += strlen(pDriver) + 1;//定位到下一个字符串，加1是为了跳过\0字符
			}
			delete [] pszDriver;
		}
		Sleep(sleep);
	}
	DWORD dwLen = GetLogicalDriveStrings(0,NULL);//获取系统盘符字符串长度
	char *pszDriver = new char[dwLen];//构建字符数组
	GetLogicalDriveStrings(dwLen,pszDriver);//获取系统盘符字符串
	char* pDriver = pszDriver;
	string s;
	while(*pDriver != '\0')
	{
		s=pDriver;
		if(pan.find(s)==pan.end())
			cp.insert(s); 
		pDriver += strlen(pDriver) + 1;//定位到下一个字符串，加1是为了跳过\0字符
	}
	delete [] pszDriver;
}
void input()//读入设置 
{
	getline(cin, tmp);
	getline(cin, from);
	trimString(from);
	from=from.find_first_not_of(" ")==-1&&to!=""? "\""+from+"\"":from; 
	getline(cin, tmp);
	getline(cin, name);
	trimString(name);
	getline(cin, tmp);
	getline(cin, to);
	trimString(to);
	to=to.find_first_not_of(" ")==-1&&to!=""? "\""+to+"\"":to; 
	getline(cin, tmp);
	getline(cin, mx);
	trimString(mx);
	getline(cin, tmp);
	getline(cin, mn);
	trimString(mn);
	getline(cin, tmp);
	getline(cin, maxage);
	trimString(maxage);
	getline(cin, tmp);
	getline(cin, minage);
	trimString(minage);
	getline(cin, tmp);
	getline(cin, maxlad);
	trimString(maxlad);
	getline(cin, tmp);
	getline(cin, minlad);
	trimString(minlad);
	getline(cin, tmp);
	getline(cin, r);
	trimString(r);
	getline(cin, tmp);
	getline(cin, w);
	trimString(w);
	getline(cin, tmp);
	getline(cin, lev);
	trimString(lev);
	getline(cin, tmp);
	getline(cin, mt);
	trimString(mt);
	getline(cin, tmp);
	getline(cin, lg);
	trimString(lg);
	getline(cin, tmp);
	getline(cin, wait);
	trimString(wait);
	stringstream ss;
	ss << wait;
	ss >> sleep;
	getline(cin,tmp);
	getline(cin,leng);
	trimString(leng);
	if(sleep==0) sleep=10;
	getline(cin,tmp);
	cin>>new_floder;
}
string GetProgramDir()  
{   
    char exeFullPath[MAX_PATH]; // Full path
    string strPath = "";
 
    GetModuleFileName(NULL,exeFullPath,MAX_PATH);
    strPath=(string)exeFullPath;    // Get full path of the file
    int pos = strPath.find_last_of('\\', strPath.length());
    return strPath.substr(0, pos);  // Return the directory without the file name
}  
int main()
{
	freopen("setup.txt","r",stdin); 
	ofstream fout;
    SYSTEMTIME sys; 
    fout.open("main_log.txt",ios::app);
	GetLocalTime( &sys );
	fout<<"\n\n";
	fout<<sys.wYear<<"年"<<sys.wMonth<<"月"<<sys.wDay<<"日    "<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    星期"<<days[sys.wDayOfWeek]<<"    程序启动\n";
	fout<<"-----------------------------------------------------------------\n";
	fout.close(); 
	input();
	GetLocalTime( &sys );
	fout.open("main_log.txt",ios::app);
	fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    ";
	fout<<"配置信息读入完成\n";
	fout.close();
	string mlog;
	mlog="cd "+to;
	if(system(mlog.c_str()))
	{
		GetLocalTime( &sys );
		fout.open("main_log.txt",ios::app);
		fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    ";
		fout<<"找不到目标目录,";
		fout<<"程序退出\n";
		fout<<"-----------------------------------------------------------------\n";
		fout.close(); 
		return 0;
	}
	if(mt!=""&&leng!="") return 0;
	int size;//要执行操作的磁盘个数 
	if (from == "")//自动识别盘符 
	{
		diskCount = GetLogicalDrives();
		DWORD dwLen = GetLogicalDriveStrings(0,NULL);//获取系统盘符字符串长度
		char *pszDriver = new char[dwLen];//构建字符数组
		GetLogicalDriveStrings(dwLen,pszDriver);//获取系统盘符字符串
		char* pDriver = pszDriver;
		string s;
		while(*pDriver != '\0')
		{
			s=pDriver;
			pan.insert(s); 
			pDriver += strlen(pDriver) + 1;//定位到下一个字符串，加1是为了跳过\0字符
		}
		delete [] pszDriver;
		check();//初始化完毕,检查u盘是否插入 
	}
	else
	{
		cp.insert(from);//待操作盘符只有一个 
		tmp = from[0];
		tmp += from[1];
		int is = -1;
		while (!is == 0)//未检测到盘符 
		{
			is = system(tmp.c_str());//再检测一遍 
			Sleep(sleep);//等待时间 
		}
		GetLocalTime( &sys );
		fout.open("main_log.txt",ios::app);
		fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    ";
		fout<<"磁盘已插入\n";
		fout.close();
	}
	if(to=="")
	{
		to=GetProgramDir();
		fout.open("main_log.txt",ios::app);
		fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    ";
		fout<<"文件保存目录:"<<to+"\n";
		fout.close();
		cout<<to<<endl; 
	} 
	if(new_floder)
	{
		int fn=0;
		string f;
		stringstream n;
		string out;
		if(to=="")
		out="mkdir files";
		else out="cd "+to+" & "+"mkdir files";
		while(system(out.c_str()))
		{
			fn++;
			n.clear();
			n<<fn;
			f.clear();
			n>>f;
			if(to=="")
			out="mkdir files";
			else out="cd "+to+" & "+"mkdir files"+f;
		}
		GetLocalTime( &sys );
		fout.open("main_log.txt",ios::app);
		fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    名为 files"<<f<<" 的目录建立完毕"<<"\n";
		fout.close();
		if(to=="") 
		to="files"+f;
		else
		to=to+"\\files"+f;
	}
	size = cp.size();//待操作盘符个数 
	if(to.find(' ')) to="\""+to+"\"";
	for (int i = 0; i < size; i++)
	{
		from = *cp.begin();
		string fu1=from;
		string fu;
		fu=fu1[0];
		fu+=fu1[1];
		cp.erase(from);//取出待操作盘符 	
  	 	DWORD dwTotalClusters;//总的簇
  		DWORD dwFreeClusters;//可用的簇
  		DWORD dwSectPerClust;//每个簇有多少个扇区
  		DWORD dwBytesPerSect;//每个扇区有多少个字节
  		BOOL bResult = GetDiskFreeSpace(fu.c_str(),&dwSectPerClust, &dwBytesPerSect, &dwFreeClusters, &dwTotalClusters);
  		while(!bResult)//持续监察直到磁盘准备好 
  		{
  			//cout<<fu<<endl;
  			Sleep(sleep);
  			bResult = GetDiskFreeSpace(fu.c_str(),&dwSectPerClust, &dwBytesPerSect, &dwFreeClusters, &dwTotalClusters);
		}
		GetLocalTime( &sys );
		fout.open("main_log.txt",ios::app);
		fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    检测到磁盘插入,文件源为:"<<from<<",开始执行第"<<i+1<<"次复制\n";
		fout.close();
		tmp = "robocopy " + from + " " + to + " " + name + " /S /R:0 /MAX:" + mx + " /MIN:" + mn + " /MAXAGE:" + maxage + " /MINAGE:" + minage + " /MAXLAD:" + maxlad + " /MINLAD:" + minlad + " /r:" + r + " /w:" + w;
		if(lev!="") tmp=tmp + " /LEV:" + lev;
		if(mt!="") tmp=tmp + " /MT:" + mt;
		if(leng!="") tmp=tmp + " /IPG:" + leng;
		if(lg!="") tmp=tmp + " /LOG+:" + lg;
		//cout<<tmp<<endl;
		system(tmp.c_str());//执行复制操作
		fout.open("main_log.txt",ios::app);
		fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    第"<<i+1<<"次复制已执行完毕\n";
		fout.close();
	}
	system("for /f \"tokens=*\" %i in ('dir/s/b/ad^|sort /r') do rd \"%i\"");//清理空文件夹 
	GetLocalTime( &sys );
	fout.open("main_log.txt",ios::app);
	fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    空文件夹清理完成\n";
	fout.close();
	tmp="ATTRIB "+to+" -s -h";
	system(tmp.c_str());
	GetLocalTime( &sys );
	fout.open("main_log.txt",ios::app);
	fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    已取消文件夹隐藏状态\n";
	fout.close(); 
	fout.open("main_log.txt",ios::app);
	GetLocalTime( &sys );
	fout<<sys.wHour<<":"<<sys.wMinute<<":"<<sys.wSecond<<"    程序退出\n";
	fout<<"-----------------------------------------------------------------\n";
	fout.close(); 
	fclose(stdin);
	fclose(stdin);
	return 0;
}
