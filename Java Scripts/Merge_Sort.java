/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package merge_sort;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;

/**
 *
 * @author Kacper
 */
public class Merge_Sort {

    /**
     * @param args the command line arguments
     */
    public static void mergeSort(int[]tab,int pocz,int koniec){
        if(pocz<koniec){
            int srodek=(pocz+koniec)/2;
            mergeSort(tab,pocz,srodek);
            mergeSort(tab,srodek+1,koniec);
            scal(tab,pocz,srodek,koniec);
        }
    }
    public static void scal(int[]tab,int pocz,int srodek,int koniec){
        int [] tab_pom=new int[tab.length];
        for(int i=pocz;i<=koniec;i++){
            tab_pom[i]=tab[i];
        }
        int pom_lewy=pocz; //zmienna pomocnicza określająca położenie w pierwszej części podzielonej tablicy na dwa
        int pom_prawy=srodek+1; //zmienna pomocnicza określająca położenie w drugiej części podzielonej tablicy na dwa
        int aktualne_polozenie=pocz; //zmienna pomocnicza określająca położenie w naszej oryginalnej tabeli
        while(pom_lewy <=srodek && pom_prawy<=koniec){
            if(tab_pom[pom_lewy]<=tab_pom[pom_prawy]){
                tab[aktualne_polozenie]=tab_pom[pom_lewy];
                pom_lewy++;
            }else{
                tab[aktualne_polozenie]=tab_pom[pom_prawy]; 
                pom_prawy++;
            }
            aktualne_polozenie++;
        }
        while(pom_lewy<=srodek){ //jeśli wszystko zostało wpisane z drugiej części podzielonej tablicy, to wpisujemy reszte niewpisanych liczb z pierwszej części tablicy
            tab[aktualne_polozenie]=tab_pom[pom_lewy];
            pom_lewy++;
            aktualne_polozenie++;
        }
    }
    public static void main(String[] args) throws FileNotFoundException {
        // TODO code application logic here
        Scanner odczyt = new Scanner(new File("liczby.txt"));
        Scanner odczyt2 = new Scanner(new File("liczby.txt"));
        PrintWriter zapis = new PrintWriter("Posortowane_liczby_merge_sort.txt");
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
        mergeSort(tab,0,tab.length-1);
        System.out.println("Zapisywanie posortowanych liczb do pliku.");
        for(int i=0;i<tab.length;i++){
            zapis.print(tab[i]+"\n");
        }
        zapis.close();
        System.out.println("Liczby zostały posortowane i zapisane w pliku Posortowane_liczby_merge_sort.txt");
    }
    
}
