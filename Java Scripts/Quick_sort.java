/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package quick_sort;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;

/**
 *
 * @author Kacper
 */
public class Quick_sort {

    /**
     * @param args the command line arguments
     */
    public static void quickSort(int tab[], int pocz, int koniec) {
        if(pocz>=koniec){
        return;
        }
        int pivot=tab[koniec]; 
        int granica=pocz-1; //granica pomagająca oddzielić liczby inne od pivota na lewą i prawą stronę
        int licznik=pocz; //licznik przemieszczający się po tablicy
        
        while(licznik<koniec){//dopóki nie dotrzemy do końca tablicy
            if(tab[licznik]<pivot){ //czy liczba jest mniejsza od pivota
                granica++; //przesuwamy granicę
                if(granica!=licznik){
                    int zamiana=tab[granica];
                    tab[granica]=tab[licznik];
                    tab[licznik]=zamiana;
                }
            }
            licznik++;
        }
        granica++;
        if(granica!=koniec){
            int zamiana=tab[granica];
            tab[granica]=tab[koniec];
            tab[koniec]=zamiana;
        }
        quickSort(tab,pocz,granica-1); //nie uwzględniamy już piwota dlatego granica-1
        quickSort(tab,granica+1,koniec); //nie uwzględniamy już piwota dlatego granica+1
    }
    public static void main(String[] args) throws FileNotFoundException {
        // TODO code application logic here
        Scanner odczyt = new Scanner(new File("liczby.txt"));
        Scanner odczyt2 = new Scanner(new File("liczby.txt"));
        PrintWriter zapis = new PrintWriter("Posortowane_liczby_quick_sort.txt");
        int ilosc_liczb=0;
        System.out.println("Wczytywanie liczb z pliku.");
        while(odczyt.hasNextInt()){
            int a=odczyt.nextInt();
            ilosc_liczb++;
        } 
        odczyt.close();
        int [] tab=new int[ilosc_liczb];
        for(int i=0;i<tab.length;i++){
            tab[i]=odczyt2.nextInt();
        }
        odczyt2.close();
        System.out.println("Sortowanie liczb.");
        quickSort(tab,0,tab.length-1);
        System.out.println("Zapisywanie posortowanych liczb do pliku.");
        for(int i=0;i<tab.length;i++){
            zapis.print(tab[i]+"\n");
        }
        zapis.close();
        System.out.println("Liczby zostały posortowane i zapisane w pliku Posortowane_liczby_quick_sort.txt");
        
    }
    
}
