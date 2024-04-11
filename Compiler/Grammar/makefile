all: 
    clean compile run

compile:
    clang -O3 output.ll -o output.exe
    
clean:
    rm -f output.exe
    
run: 
    ./output.exe