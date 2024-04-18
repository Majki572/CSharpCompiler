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
@str.4 = private unnamed_addr constant [7 x i8] c"ala ma\00"
@str.5 = private unnamed_addr constant [12 x i8] c"TRUE INDEED\00"
@str.6 = private unnamed_addr constant [6 x i8] c"Hello\00"
@str.7 = private unnamed_addr constant [6 x i8] c"World\00"
@str.8 = private unnamed_addr constant [2 x i8] c" \00"
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
%aaaa = alloca i32
store i32 999, i32* %aaaa
%11 = load i32, i32* %aaaa
%12 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %11)
%13 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* %aaaa)
%14 = load i32, i32* %aaaa
%15 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %14)
%ala = alloca i8*
%16 = call i8* @malloc(i64 7)
store i8* %16, i8** %ala
%17 = load i8*, i8** %ala
%18 = call i8* @strcpy(i8* %17, i8* getelementptr inbounds ([7 x i8], [7 x i8]* @str.4, i64 0, i64 0))
%19 = load i8*, i8** %ala
%20 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %19)
%21 = load i8*, i8** %ala
%22 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %21)
%23 = load i8*, i8** %ala
%24 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %23)
%trulizna = alloca i1
store i1 1, i1* %trulizna
%25 = load i1, i1* %trulizna
br i1 %25, label %true8, label %false8
true8:
%26 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* getelementptr inbounds ([12 x i8], [12 x i8]* @str.5, i64 0, i64 0))
%b = alloca i16
store i16 1, i16* %b
%27 = load i16, i16* %b
%28 = sext i16 %27 to i32
%29 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %28)
store i16 2, i16* %b
%30 = load i16, i16* %b
%31 = sext i16 %30 to i32
%32 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %31)
%33 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i16* %b)
%34 = load i16, i16* %b
%35 = sext i16 %34 to i32
%36 = load i16, i16* %b
%37 = sext i16 %36 to i32
%38 = add i32 %35, %37
%39 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %38)
%40 = load i16, i16* %b
%41 = sext i16 %40 to i32
%42 = load i16, i16* %b
%43 = sext i16 %42 to i32
%44 = sub i32 %41, %43
%45 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %44)
%46 = load i16, i16* %b
%47 = sext i16 %46 to i32
%48 = load i16, i16* %b
%49 = sext i16 %48 to i32
%50 = sdiv i32 %47, %49
%51 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %50)
%52 = load i16, i16* %b
%53 = sext i16 %52 to i32
%54 = load i16, i16* %b
%55 = sext i16 %54 to i32
%56 = mul i32 %53, %55
%57 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %56)
%a = alloca i32
store i32 5, i32* %a
%58 = load i32, i32* %a
%59 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %58)
store i32 16, i32* %a
%60 = load i32, i32* %a
%61 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %60)
%62 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsd, i64 0, i64 0), i32* %a)
%63 = load i32, i32* %a
%64 = load i32, i32* %a
%65 = add i32 %63, %64
%66 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %65)
%67 = load i32, i32* %a
%68 = load i32, i32* %a
%69 = sub i32 %67, %68
%70 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %69)
%71 = load i32, i32* %a
%72 = load i32, i32* %a
%73 = sdiv i32 %71, %72
%74 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %73)
%75 = load i32, i32* %a
%76 = load i32, i32* %a
%77 = mul i32 %75, %76
%78 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %77)
%c = alloca i64
store i64 10000000, i64* %c
%79 = load i64, i64* %c
%80 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %79)
store i64 200000000, i64* %c
%81 = load i64, i64* %c
%82 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %81)
%83 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strslld, i64 0, i64 0), i64* %c)
%84 = load i64, i64* %c
%85 = load i64, i64* %c
%86 = add i64 %84, %85
%87 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %86)
%88 = load i64, i64* %c
%89 = load i64, i64* %c
%90 = sub i64 %88, %89
%91 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %90)
%92 = load i64, i64* %c
%93 = load i64, i64* %c
%94 = sdiv i64 %92, %93
%95 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %94)
%96 = load i64, i64* %c
%97 = load i64, i64* %c
%98 = mul i64 %96, %97
%99 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @strplld, i64 0, i64 0), i64 %98)
%d = alloca float
store float 1.5, float* %d
%100 = load float, float* %d
%101 = fpext float %100 to double
%102 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %101)
store float 2.5, float* %d
%103 = load float, float* %d
%104 = fpext float %103 to double
%105 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %104)
%106 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strsf, i64 0, i64 0), float* %d)
%107 = load float, float* %d
%108 = load float, float* %d
%109 = fadd float %107, %108
%110 = fpext float %109 to double
%111 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %110)
%112 = load float, float* %d
%113 = load float, float* %d
%114 = fsub float %112, %113
%115 = fpext float %114 to double
%116 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %115)
%117 = load float, float* %d
%118 = load float, float* %d
%119 = fdiv float %117, %118
%120 = fpext float %119 to double
%121 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %120)
%122 = load float, float* %d
%123 = load float, float* %d
%124 = fmul float %122, %123
%125 = fpext float %124 to double
%126 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpf, i64 0, i64 0), double %125)
%e = alloca double
store double 1.5, double* %e
%127 = load double, double* %e
%128 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %127)
store double 2.5, double* %e
%129 = load double, double* %e
%130 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %129)
%131 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strslf, i64 0, i64 0), double* %e)
%132 = load double, double* %e
%133 = load double, double* %e
%134 = fadd double %132, %133
%135 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %134)
%136 = load double, double* %e
%137 = load double, double* %e
%138 = fsub double %136, %137
%139 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %138)
%140 = load double, double* %e
%141 = load double, double* %e
%142 = fdiv double %140, %141
%143 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %142)
%144 = load double, double* %e
%145 = load double, double* %e
%146 = fmul double %144, %145
%147 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @strplf, i64 0, i64 0), double %146)
%f = alloca i8*
%148 = call i8* @malloc(i64 6)
store i8* %148, i8** %f
%149 = load i8*, i8** %f
%150 = call i8* @strcpy(i8* %149, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.6, i64 0, i64 0))
%151 = load i8*, i8** %f
%152 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %151)
%153 = call i8* @malloc(i64 6)
store i8* %153, i8** %f
%154 = load i8*, i8** %f
%155 = call i8* @strcpy(i8* %154, i8* getelementptr inbounds ([6 x i8], [6 x i8]* @str.7, i64 0, i64 0))
%156 = load i8*, i8** %f
%157 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %156)
%158 = load i8*, i8** %f
%159 = call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @strss, i64 0, i64 0), i8* %158)
%160 = load i8*, i8** %f
%161 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %160)
%162 = load i8*, i8** %f
%163 = load i8*, i8** %f
%164 = alloca i8*
%165 = call i8* @malloc(i64 11)
store i8* %165, i8** %164
%166 = call i8* @strcat(i8* %165, i8* %162)
%167 = call i8* @strcat(i8* %166, i8* %163)
%168 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %167)
%169 = load i8*, i8** %f
%170 = load i8*, i8** %f
%171 = alloca i8*
%172 = call i8* @malloc(i64 7)
store i8* %172, i8** %171
%173 = call i8* @strcat(i8* %172, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.8, i64 0, i64 0))
%174 = call i8* @strcat(i8* %173, i8* %170)
%175 = alloca i8*
%176 = call i8* @malloc(i64 12)
store i8* %176, i8** %175
%177 = call i8* @strcat(i8* %176, i8* %169)
%178 = call i8* @strcat(i8* %177, i8* %174)
%179 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %178)
%180 = load i8*, i8** %f
%181 = load i8*, i8** %f
%182 = load i8*, i8** %f
%183 = alloca i8*
%184 = call i8* @malloc(i64 7)
store i8* %184, i8** %183
%185 = call i8* @strcat(i8* %184, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.8, i64 0, i64 0))
%186 = call i8* @strcat(i8* %185, i8* %182)
%187 = alloca i8*
%188 = call i8* @malloc(i64 12)
store i8* %188, i8** %187
%189 = call i8* @strcat(i8* %188, i8* %181)
%190 = call i8* @strcat(i8* %189, i8* %186)
%191 = alloca i8*
%192 = call i8* @malloc(i64 13)
store i8* %192, i8** %191
%193 = call i8* @strcat(i8* %192, i8* getelementptr inbounds ([2 x i8], [2 x i8]* @str.8, i64 0, i64 0))
%194 = call i8* @strcat(i8* %193, i8* %190)
%195 = alloca i8*
%196 = call i8* @malloc(i64 18)
store i8* %196, i8** %195
%197 = call i8* @strcat(i8* %196, i8* %180)
%198 = call i8* @strcat(i8* %197, i8* %194)
%199 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strps, i64 0, i64 0), i8* %198)
br label %false8
false8:
%zyzz = alloca i32
store i32 10, i32* %zyzz
%xyxx = alloca i32
store i32 0, i32* %xyxx
br label %whileCondition9
whileCondition9:
%200 = load i32, i32* %xyxx
%201 = load i32, i32* %zyzz
%202 = icmp slt i32 %200, %201
br i1 %202, label %whileTrue9, label %whileFalse9
whileTrue9:
%203 = load i32, i32* %xyxx
%204 = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @strpd, i64 0, i64 0), i32 %203)
%205 = load i32, i32* %xyxx
%206 = add i32 %205, 1
store i32 %206, i32* %xyxx
br label %whileCondition9
whileFalse9:
ret double 0.0
}
