﻿// 파이썬용 라이브러리 사용등록
using IronPython.Hosting;

namespace ex15_pythons
{
    /*
     ['', 'C:\DEV\Langs\Python311\python311.zip', 
    
    'C:\Users\user\AppData\Roaming\Python\Python311\site-packages\Pythonwin', 
    '']
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("파이썬 실행 예제");

            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var paths = engine.GetSearchPaths();

            // Python 경로 설정 @(리소스 키워드)
            paths.Add(@"C:\DEV\Langs\Python311"); // 기본 파이썬경로
            paths.Add(@"C:\DEV\Langs\Python311\DLLs");
            paths.Add(@"C:\DEV\Langs\Python311\Lib"); 
            paths.Add(@"C:\DEV\Langs\Python311\Lib\site-packages");

            paths.Add(@"C:\Users\user\AppData\Roaming\Python\Python311\site-packages\win32");
            paths.Add(@"C:\Users\user\AppData\Roaming\Python\Python311\site-packages\win32\lib");
            paths.Add(@"C:\Users\user\AppData\Roaming\Python\Python311\site-packages");


            // 실행시킬 Python 파일 경로 설정
            var filePath = @"C:\sources\basic-csharp\day03\cs_basic_app\ex15_pythons\Text.py";
            var source = engine.CreateScriptSourceFromFile(filePath);

            // Python 실행
            source.Execute(scope);

            var PythonFunc = scope.GetVariable<Func<int, int, int>>("sum");
            Console.WriteLine($"파이썬 함수 실행 = {PythonFunc(10,7)}");

            var PythonGreeting = scope.GetVariable<Func<string>>("sayGreeting");
            var greeting = PythonGreeting();
            Console.WriteLine($"결과 = {greeting}");  



        }
    }
}
