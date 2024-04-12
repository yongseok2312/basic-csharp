# C# 기본 학습
2024년 IoT개발자 과정 C# 리포지토리

## 1일차
- C# 소개
    - MS에서 개발한 차세대 프로그래밍 언어
    - 2000년 최초 발표, 앤더스 하일버그(파스칼, 델파이 개발자)
    - 1995년 JAVA 발표되면서 경쟁하기 위하여 개발
    - 객체지향 언어, c/c++과 JAVA를 참조하여 개발
    - OS플랫폼 독립적, 메모리관리 쉬움
    - 다양한 분야에서 사용 중
    - 2024년 12 버전

- .NET Framework (CLR)
    - Windows OS에 종속적
    - OS독립적인 새로운 틀을 제작하기 시작(2022년 ~) -> .NET 5.0
    - 2024년 현재 .NET 8.0
    - C/C++ gcc 컴파일러, Java는 JDK, C#은 .NET 5.0d 이상이 필요
    - 이제는 신규 개발 시, .NET Framework는 사용하지 말 것!

- Hello, C#!
    - Visual Studio 시작
    - 프로젝트 -프로그램 개발 최소단위 그룹
    - **솔루션 - 프로젝트의 묶음**

    ```cs
    namespace hello_world // 소스의 가장 큰 단위 namesapce == project
    {
     internal class Program  // 접근제한자 class 파일명
        {
          static void Main(string[] args) // 정적 void Main
             {
                // system 네임스페이스 > console  클래스에 있는 정적메서드  WriteLine()
                Console.WriteLine("Hello, World!");
            }
        }
    }
    ```

- 변수와 상수
    - C++과 동일
    - 모든 C#의 객체는 Object를 조상으로
    - 프로그램 메모리에는 스택(값형식, 정수, 실수 ...), 힙(참조형식, 클래스, 문자열, 리스트, 배열...)
    - 박싱, 언박싱
    ```cs
    int a 20;
    object b = a; // 박싱 (object 박스에 담는다)

    int c = (int) b;
    ```

    -- 상수는 const 키워드 사용
    -- var는 컴파일러가 자동으로 타입을 저장해주는 변수, 지역변수에만 사용 가능

- 연산자
    - C++과 동일
    - ++, --가 파이썬에 없다.
    - and, or가 C++,C#에서는 &&, ||라는 것
- 흐름제어
    - C++과 동일!
    - if, switch, while, do~while, for, break, continue, goto 모두 동일
    - **C#에는 foreach가 존재** - python의 for item in []과 동일

    ```cs
    int[] arr = {1,2,3,4,5};
    foreach (var item in arr)
    {
        Console.WriteLine($"현재 수 : {item}");
    }
    ```

- 메서드(Method)
    - 함수와 동일, 구조적 프로그래밍에서 함수, 객체지향에서는 메서드로 부른다(파이썬만 예외)
    - **매개변수 참조형식**-> c++에서 pointer로 값을 사용할 때와 동일한 기능
    ```cs
    public static void RefSwap(ref int a, ref int b)
    {
     int temp = b;
     b = a;
        a = temp;
    }

    // 사용시에도 ref 키워드 사용
    RefSwap(ref x, ref y)
    ```
    - 매개변수 출력형식

    ```cs
        public static void Divide(int a, int b, out int quotient, out int remainder)
    {
         quotient = a / b;
     remainder = a % b;
     // 예전엔 튜플리턴이 없어서 한번에 하나만 값을 리턴할 수 있었음. 
    }
    ```
    - 매개변수 오버로딩 - > 여러 타입으로 같은 처리를 하는 메서드
    - 매개변수 가변길이
    ```cs
    public static int Sum(params int[] argv)
    ```
    - 명명된 매개변수
    ```cs
        public static void PrintProfile(string name, string phone)
    {
     Console.WriteLine($"이름 = {name}, 모바일 = {phone}");   
    }
    ```
    - 기본 값 매개변수
    ```cs
        public static void DefalutMethod(int a = 1, int b = 0)
    {
        Console.WriteLine($"Defalut Value = {a}, {b}");
    }
    ```

- 클래스
    - C++의 클래스, 객체와 유사(문법이 다소 상이)
    - 생성자는 new로 사용해서 객체 생성
    - 종료자(파괴자)는 C#에선 거의 사용안함
    - 생성자 오버로딩 -> 파라미터 개수에 따라서 사용가능, 기본적인 메서드 오버로딩하고 기능 동일
    - this 키워드 -> C++ this ->라면 , C# this, 파이썬의 self와 동일
    - 접근한정자(Acess Modifier)
        - public       - 모든 곳에서 접근
        - private      - 외부에서 접근 불가
        - protected    - 외부에서 접근 불가, 파생(상속)클래스에서는 상속 가능
        - internal     - 같은 어셈블리(네임스페이스)네에서는 public과 동일
        - protected internal, private protected - 난이도 있는 한정자(고급)

    - C#에는 C++과 같은 다중상속 없음. C++ 다중상속으로 생기는 문제점을 해결하기 위해서 다중상속을 아예 없앰
        - 다중상속이 필요함을 해결 -> 인터페이스 
        ```cs
        class BaseClass{
            // 부모클래스
        }
        class DerivedClass : BaseClass{
            // 자식 클래스
        }
        ```

- 구조체
    - 객체지향이 없었을때 좀더 객체지향적인 프로그래밍을 위해서 만들어진 부분 (c에서)
    - class이후로 사용빈도가 완전히 줄어든 구조
    - 구조체 스택(값형식), 클래스 힙(참조형식)
    - C#에서는 구조체 안써도 댐

- 튜플 (C# 7.0 이후 반영)
    - 한꺼번에 여러개의 데이터를 리턴하거나 전달할 때 유용
    - 값 할당 후 변경불가

- **인터페이스**
    - 클래스 - 객체의 청사진 / 인터페이스 - 클래스의 청사진(?)
    - 인터페이스는 클래스가 어떠한 메서드를 가져야 하는지를 약속하는 것
    - 다중상속의 문제를 단일상속으로도 해결하게 만든 주체
    - 인터페이스는 명명할 때 제일 앞에 I를 적음
    - 인터페이스의 메서드에는 구현을 작성하지 않음
    - 인터페이스는 약속
    - 클래스는 상속한다 vs 인터페이스 구현한다.
    - 클래스는 상속 시 별다른 문제없음 vs 인터페이스는 구현을 하면 약속을 지키지 않으면 오류표시
    - 인터페이스에서 약속한 메서드를 구현하지 않으면 빌드가 안됨
    ![cs001](https://github.com/yongseok2312/basic-csharp/assets/135982451/f5ea68f6-70d2-4fd8-a583-f9677da92209)

- 추상클래스(abstract)
    - virtual 메서드하고도 유사
    - 추상클래스를 단순화 시키면 인터페이스

- **프로퍼티**
    - 클래스의 멤버변수 변형, 일반 변수와 유사
    - 멤버변수의 접근제한자를 public으로 했을 때의 객체지향적 문제점(코드 오염 등)을 해결하기 위해서
    - GET 접근자/SET  접근자
    - SET은 값 할당시에 잘못된 데이터가 들어가지 않도록 막아야 함
    - Java에선 Getter 메서드/Setter메서드로 사용

## 2일차
- TIP, C# 에서 빌드 시 오류 해결
    - 빌드하고자하는 프로그램이 백그라운드 상에 실행중이기 때문
    - CTRL + SHIFT + ESC (작업관리자)에서 해당 프로세스 작업 끝내기 후
    - 재빌드

- 컬렉션(배열, 리스트, 인덱서)
    - 모든 배열은 system.Array 클래스를 상속한 하위 클래스
    - 기본적인 배열의 사용법, Python 리스트와도 동일
    - 배열 분할 - C# 8.0부터 파이썬의 배열 슬라이스를 도입
    - 컬렉션 == 파이썬의 리스트, 스택, 큐, 딕셔너리와 동일
        - ArrayList
        - Stack
        - Queue
        - Hashtable ( == Dictionary)
    - foreach를 사용할 수 있는 객체로 만들기 - yield

- 일반화(Generic) 프로그래밍
    - 파이썬 - 변수에 제약사항 없음
    - 타입의 제약을 해소하고자 만든 기능. ArrayList 등이 해결(단, 박싱(언박싱)등 성능의 문제가 있음)
    - **하나의 메서드로 여러 타입의 처리를 해줄 수 있는 프로그래밍 방식**
    - 일반화 컬렉션
        - List<T>
        - Stack<T>, Queue<T>
        - Dictionary<TKey, TValue>

- 예외처리
    - 소스코드 상 문법적 오류 - 오류(Error)
    - 실행 중 생기는 오류 - 예외(Exception)
    ```cs
    try{
        // 예외가 발생할 것 같은 소스코드
    }
    catch(Exception ex){
        /* 모든 예외 클래스의 조상은 Exception(예 IndexOutOfRangeException)
           어떤 예외클래스를 쓸지 모르면 무조고 Exception 클래스를 사용하면 됨
           */
        Console.WriteLine(ex.Message);
    }
    finally{
        // 예외 발생 유무에 상관없이 항상 실행
    }
    ```
- 대리자와 이벤트
    - 메서드 호출 시 매개변수 전달
    - 대리자 호출 시 함수(메서드) 자체를 전달
    - 이벤트 - 컴퓨터 내에서 발생하는 객체의 사건들
    - delegate --> event
    - 윈폼개발 --> 이벤트 기반 프로그래밍

- TIP, C# 주석 중 영역을 지정할 수 있는 주석
    - #region ~ #endregion 영역을 Expend 또는 Collapse 가능
![cs002](https://github.com/yongseok2312/basic-csharp-2024/assets/135982451/9e6cb96c-e3ea-406d-854e-738b85b51c85)


## 3일차
- 람다식
- LINQ
- 애트리뷰트
- 파이썬 실행
- Winform UI 개발 + 파일, 스레드
- 가비지 컬렉션
- 네트워크 프로그래밍

## 4일차
- WRF
- 예제 프로젝트
