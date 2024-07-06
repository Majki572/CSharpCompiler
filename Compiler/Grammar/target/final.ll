declare i32 @printf(i8*, ...)
declare i32 @__isoc99_scanf(i8*, ...)
declare noalias i8* @malloc(i64)
declare i8* @strcpy(i8*, i8*)
declare i8* @strcat(i8*, i8*)
@strpd = constant [4 x i8] c"%d\0A\00"
@strplld = constant [6 x i8] c"%lld\0A\00"
@strpf = constant [4 x i8] c"%f\0A\00"
@strplf = constant [5 x i8] c"%lf\0A\00"
@strshd = constant [4 x i8] c"%hd\00"
@strsd = constant [3 x i8] c"%d\00"
@strslld = constant [5 x i8] c"%lld\00"
@strsf = constant [3 x i8] c"%f\00"
@strslf = constant [4 x i8] c"%lf\00"
@strss = constant [3 x i8] c"%s\00"
@strps = constant [4 x i8] c"%s\0A\00"
%struct.temp = type { i32, i32, double }
@str.0 = private unnamed_addr constant [8 x i8] c"SUCCESS\00"
@str.1 = private unnamed_addr constant [9 x i8] c"is equal\00"
@str.2 = private unnamed_addr constant [8 x i8] c"is less\00"
@str.3 = private unnamed_addr constant [17 x i8] c"is less or equal\00"
@str.4 = private unnamed_addr constant [28 x i8] c"aaaaaaaaaaaaaaaaaaaaaaaaaaa\00"
@str.5 = private unnamed_addr constant [7 x i8] c"ala ma\00"
@str.6 = private unnamed_addr constant [12 x i8] c"TRUE INDEED\00"
@str.7 = private unnamed_addr constant [6 x i8] c"Hello\00"
@str.8 = private unnamed_addr constant [6 x i8] c"World\00"
@str.9 = private unnamed_addr constant [2 x i8] c" \00"
define i32 @mama(i32 %0, i32 %1) {
%a = alloca i32
store i32 %0, i32* %a
%b = alloca i32
store i32 %1, i32* %b
%3 = load i32, i32* %a
%4 = load i32, i32* %b
%5 = add i32 %3, %4
%c = alloca i32
store i32 %5, i32* %c
%6 = load i32, i32* %c
%7 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %6)
%ele = alloca %struct.temp*
%8 = call i8* @malloc(i64 16)
%9 = bitcast i8* %8 to %struct.temp*
store %struct.temp* %9, %struct.temp** %ele
%10 = load %struct.temp*, %struct.temp** %ele
%11 = getelementptr inbounds %struct.temp, %struct.temp* %10, i32 0, i32 0
store i32 123, i32* %11
%12 = load %struct.temp*, %struct.temp** %ele
%13 = getelementptr inbounds %struct.temp, %struct.temp* %12, i32 0, i32 1
store i32 456, i32* %13
%14 = load %struct.temp*, %struct.temp** %ele
%15 = getelementptr inbounds %struct.temp, %struct.temp* %14, i32 0, i32 2
store double 789.123, double* %15
%16 = load %struct.temp*, %struct.temp** %ele
%17 = getelementptr inbounds %struct.temp, %struct.temp* %16, i32 0, i32 0
%18 = load i32, i32* %17
%19 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %18)
%20 = load %struct.temp*, %struct.temp** %ele
%21 = getelementptr inbounds %struct.temp, %struct.temp* %20, i32 0, i32 1
%22 = load i32, i32* %21
%23 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %22)
%24 = load %struct.temp*, %struct.temp** %ele
%25 = getelementptr inbounds %struct.temp, %struct.temp* %24, i32 0, i32 1
%26 = load i32, i32* %25
%27 = load %struct.temp*, %struct.temp** %ele
%28 = getelementptr inbounds %struct.temp, %struct.temp* %27, i32 0, i32 0
%29 = load i32, i32* %28
%30 = add i32 %26, %29
%31 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %30)
%32 = load i32, i32* %c
ret i32 %32
}
define double @ma(double %0, double %1) {
%a = alloca double
store double %0, double* %a
%b = alloca double
store double %1, double* %b
%3 = load double, double* %a
%4 = load double, double* %b
%5 = fadd double %3, %4
%c = alloca double
store double %5, double* %c
%testowa = alloca i32
store i32 5, i32* %testowa
%6 = load double, double* %c
ret double %6
}
define i32 @mammamia() {
%success = alloca i8*
%1 = call i8* @malloc(i64 8)
store i8* %1, i8** %success
%2 = load i8*, i8** %success
%3 = call i8* @strcpy(i8* %2, i8* getelementptr inbounds ([8 x i8], [8 x i8]* @str.0, i64 0, i64 0))
%a = alloca i32
store i32 7, i32* %a
%b = alloca i32
store i32 8, i32* %b
%4 = load i32, i32* %a
%5 = load i32, i32* %b
%6 = icmp eq i32 %4, %5
br i1 %6, label %true1, label %false1
true1:
%7 = load i8*, i8** %success
%8 = alloca i8*
%9 = call i8* @malloc(i64 16)
store i8* %9, i8** %8
%10 = call i8* @strcat(i8* %9, i8* %7)
%11 = call i8* @strcat(i8* %10, i8* getelementptr inbounds ([9 x i8], [9 x i8]* @str.1, i64 0, i64 0))
%12 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %11)
br label %false1
false1:
%13 = load i32, i32* %a
%14 = load i32, i32* %b
%15 = icmp ne i32 %13, %14
br i1 %15, label %true2, label %false2
true2:
%16 = load i8*, i8** %success
%17 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %16)
br label %false2
false2:
%18 = load i32, i32* %a
%19 = load i32, i32* %b
%20 = icmp slt i32 %18, %19
br i1 %20, label %true3, label %false3
true3:
%21 = load i8*, i8** %success
%22 = alloca i8*
%23 = call i8* @malloc(i64 15)
store i8* %23, i8** %22
%24 = call i8* @strcat(i8* %23, i8* %21)
%25 = call i8* @strcat(i8* %24, i8* getelementptr inbounds ([8 x i8], [8 x i8]* @str.2, i64 0, i64 0))
%26 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %25)
br label %false3
false3:
%27 = load i32, i32* %a
%28 = load i32, i32* %b
%29 = icmp sgt i32 %27, %28
br i1 %29, label %true4, label %false4
true4:
%30 = load i8*, i8** %success
%31 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %30)
br label %false4
false4:
%32 = load i32, i32* %a
%33 = load i32, i32* %b
%34 = icmp sle i32 %32, %33
br i1 %34, label %true5, label %false5
true5:
%35 = load i8*, i8** %success
%36 = alloca i8*
%37 = call i8* @malloc(i64 24)
store i8* %37, i8** %36
%38 = call i8* @strcat(i8* %37, i8* %35)
%39 = call i8* @strcat(i8* %38, i8* getelementptr inbounds ([17 x i8], [17 x i8]* @str.3, i64 0, i64 0))
%40 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %39)
br label %false5
false5:
%41 = load i32, i32* %a
%42 = load i32, i32* %b
%43 = icmp sge i32 %41, %42
br i1 %43, label %true6, label %false6
true6:
%44 = load i8*, i8** %success
%45 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %44)
br label %false6
false6:
%x = alloca i32
store i32 0, i32* %x
%y = alloca i32
store i32 9, i32* %y
br label %whileCondition7
whileCondition7:
%46 = load i32, i32* %x
%47 = load i32, i32* %y
%48 = icmp slt i32 %46, %47
br i1 %48, label %whileTrue7, label %whileFalse7
whileTrue7:
%49 = load i32, i32* %x
%50 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %49)
%51 = load i32, i32* %x
%52 = add i32 %51, 1
store i32 %52, i32* %x
br label %whileCondition7
whileFalse7:
ret i32 0
}
define double @main() {
%1 = call i32 @mammamia()
%atete = alloca i32
store i32 %1, i32* %atete
%testowa = alloca i32
store i32 3, i32* %testowa
%dddd = alloca i32
store i32 5, i32* %dddd
%2 = load i32, i32* %dddd
%3 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %2)
%4 = load i32, i32* %dddd
%5 = call i32 @mama(i32 %4, i32 100)
%eeee = alloca i32
store i32 %5, i32* %eeee
%6 = call double @ma(double 4.4, double 5.5)
%ffff = alloca double
store double %6, double* %ffff
%7 = load i32, i32* %eeee
%8 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %7)
%9 = load double, double* %ffff
%10 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %9)
%11 = load i32, i32* %testowa
%12 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %11)
%13 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* getelementptr inbounds ([28 x i8], [28 x i8]* @str.4, i64 0, i64 0))
%aaaa = alloca i32
store i32 999, i32* %aaaa
%14 = load i32, i32* %aaaa
%15 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %14)
%16 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* %aaaa)
%17 = load i32, i32* %aaaa
%18 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %17)
%ala = alloca i8*
%19 = call i8* @malloc(i64 7)
store i8* %19, i8** %ala
%20 = load i8*, i8** %ala
%21 = call i8* @strcpy(i8* %20, i8* getelementptr inbounds ([7 x i8], [7 x i8]* @str.5, i64 0, i64 0))
%22 = load i8*, i8** %ala
%23 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %22)
%24 = load i8*, i8** %ala
%25 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %24)
%26 = load i8*, i8** %ala
%27 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %26)
%trulizna = alloca i1
store i1 1, i1* %trulizna
%28 = load i1, i1* %trulizna
br i1 %28, label %true8, label %false8
true8:
%29 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* getelementptr inbounds ([12 x i8], [12 x i8]* @str.6, i64 0, i64 0))
%b = alloca i16
store i16 1, i16* %b
%30 = load i16, i16* %b
%31 = sext i16 %30 to i32
%32 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %31)
store i16 2, i16* %b
%33 = load i16, i16* %b
%34 = sext i16 %33 to i32
%35 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %34)
%36 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i16* %b)
%37 = load i16, i16* %b
%38 = sext i16 %37 to i32
%39 = load i16, i16* %b
%40 = sext i16 %39 to i32
%41 = add i32 %38, %40
%42 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %41)
%43 = load i16, i16* %b
%44 = sext i16 %43 to i32
%45 = load i16, i16* %b
%46 = sext i16 %45 to i32
%47 = sub i32 %44, %46
%48 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %47)
%49 = load i16, i16* %b
%50 = sext i16 %49 to i32
%51 = load i16, i16* %b
%52 = sext i16 %51 to i32
%53 = sdiv i32 %50, %52
%54 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %53)
%55 = load i16, i16* %b
%56 = sext i16 %55 to i32
%57 = load i16, i16* %b
%58 = sext i16 %57 to i32
%59 = mul i32 %56, %58
%60 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %59)
%a = alloca i32
store i32 5, i32* %a
%61 = load i32, i32* %a
%62 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %61)
store i32 16, i32* %a
%63 = load i32, i32* %a
%64 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %63)
%65 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* %a)
%66 = load i32, i32* %a
%67 = load i32, i32* %a
%68 = add i32 %66, %67
%69 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %68)
%70 = load i32, i32* %a
%71 = load i32, i32* %a
%72 = sub i32 %70, %71
%73 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %72)
%74 = load i32, i32* %a
%75 = load i32, i32* %a
%76 = sdiv i32 %74, %75
%77 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %76)
%78 = load i32, i32* %a
%79 = load i32, i32* %a
%80 = mul i32 %78, %79
%81 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %80)
%c = alloca i64
store i64 10000000, i64* %c
%82 = load i64, i64* %c
%83 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %82)
store i64 200000000, i64* %c
%84 = load i64, i64* %c
%85 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %84)
%86 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strslld, i64 0, i64 0), i64* %c)
%87 = load i64, i64* %c
%88 = load i64, i64* %c
%89 = add i64 %87, %88
%90 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %89)
%91 = load i64, i64* %c
%92 = load i64, i64* %c
%93 = sub i64 %91, %92
%94 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %93)
%95 = load i64, i64* %c
%96 = load i64, i64* %c
%97 = sdiv i64 %95, %96
%98 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %97)
%99 = load i64, i64* %c
%100 = load i64, i64* %c
%101 = mul i64 %99, %100
%102 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %101)
%d = alloca float
store float 1.5, float* %d
%103 = load float, float* %d
%104 = fpext float %103 to double
%105 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %104)
store float 2.5, float* %d
%106 = load float, float* %d
%107 = fpext float %106 to double
%108 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %107)
%109 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsf, i64 0, i64 0), float* %d)
%110 = load float, float* %d
%111 = load float, float* %d
%112 = fadd float %110, %111
%113 = fpext float %112 to double
%114 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %113)
%115 = load float, float* %d
%116 = load float, float* %d
%117 = fsub float %115, %116
%118 = fpext float %117 to double
%119 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %118)
%120 = load float, float* %d
%121 = load float, float* %d
%122 = fdiv float %120, %121
%123 = fpext float %122 to double
%124 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %123)
%125 = load float, float* %d
%126 = load float, float* %d
%127 = fmul float %125, %126
%128 = fpext float %127 to double
%129 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %128)
%e = alloca double
store double 1.5, double* %e
%130 = load double, double* %e
%131 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %130)
store double 2.5, double* %e
%132 = load double, double* %e
%133 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %132)
%134 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strslf, i64 0, i64 0), double* %e)
%135 = load double, double* %e
%136 = load double, double* %e
%137 = fadd double %135, %136
%138 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %137)
%139 = load double, double* %e
%140 = load double, double* %e
%141 = fsub double %139, %140
%142 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %141)
%143 = load double, double* %e
%144 = load double, double* %e
%145 = fdiv double %143, %144
%146 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %145)
%147 = load double, double* %e
%148 = load double, double* %e
%149 = fmul double %147, %148
%150 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %149)
%f = alloca i8*
%151 = call i8* @malloc(i64 6)
store i8* %151, i8** %f
%152 = load i8*, i8** %f
%153 = call i8* @strcpy(i8* %152, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.7, i64 0, i64 0))
%154 = load i8*, i8** %f
%155 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %154)
%156 = call i8* @malloc(i64 6)
store i8* %156, i8** %f
%157 = load i8*, i8** %f
%158 = call i8* @strcpy(i8* %157, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.8, i64 0, i64 0))
%159 = load i8*, i8** %f
%160 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %159)
%161 = load i8*, i8** %f
%162 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %161)
%163 = load i8*, i8** %f
%164 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %163)
%165 = load i8*, i8** %f
%166 = load i8*, i8** %f
%167 = alloca i8*
%168 = call i8* @malloc(i64 11)
store i8* %168, i8** %167
%169 = call i8* @strcat(i8* %168, i8* %165)
%170 = call i8* @strcat(i8* %169, i8* %166)
%171 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %170)
%172 = load i8*, i8** %f
%173 = load i8*, i8** %f
%174 = alloca i8*
%175 = call i8* @malloc(i64 7)
store i8* %175, i8** %174
%176 = call i8* @strcat(i8* %175, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.9, i64 0, i64 0))
%177 = call i8* @strcat(i8* %176, i8* %173)
%178 = alloca i8*
%179 = call i8* @malloc(i64 12)
store i8* %179, i8** %178
%180 = call i8* @strcat(i8* %179, i8* %172)
%181 = call i8* @strcat(i8* %180, i8* %177)
%182 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %181)
%183 = load i8*, i8** %f
%184 = load i8*, i8** %f
%185 = load i8*, i8** %f
%186 = alloca i8*
%187 = call i8* @malloc(i64 7)
store i8* %187, i8** %186
%188 = call i8* @strcat(i8* %187, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.9, i64 0, i64 0))
%189 = call i8* @strcat(i8* %188, i8* %185)
%190 = alloca i8*
%191 = call i8* @malloc(i64 12)
store i8* %191, i8** %190
%192 = call i8* @strcat(i8* %191, i8* %184)
%193 = call i8* @strcat(i8* %192, i8* %189)
%194 = alloca i8*
%195 = call i8* @malloc(i64 13)
store i8* %195, i8** %194
%196 = call i8* @strcat(i8* %195, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.9, i64 0, i64 0))
%197 = call i8* @strcat(i8* %196, i8* %193)
%198 = alloca i8*
%199 = call i8* @malloc(i64 18)
store i8* %199, i8** %198
%200 = call i8* @strcat(i8* %199, i8* %183)
%201 = call i8* @strcat(i8* %200, i8* %197)
%202 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %201)
br label %false8
false8:
%zyzz = alloca i32
store i32 10, i32* %zyzz
%xyxx = alloca i32
store i32 0, i32* %xyxx
br label %whileCondition9
whileCondition9:
%203 = load i32, i32* %xyxx
%204 = load i32, i32* %zyzz
%205 = icmp slt i32 %203, %204
br i1 %205, label %whileTrue9, label %whileFalse9
whileTrue9:
%206 = load i32, i32* %xyxx
%207 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %206)
%208 = load i32, i32* %xyxx
%209 = add i32 %208, 1
store i32 %209, i32* %xyxx
br label %whileCondition9
whileFalse9:
ret double 0.0
}
