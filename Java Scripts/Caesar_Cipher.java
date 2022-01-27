/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package szyfr_cezara;

import java.util.Scanner;

/**
 *
 * @author Kacper
 */
public class Szyfr_cezara {

    /**
     * @param args the command line arguments
     */
    public static String szyfrowanie(String tekst){
        String zaszyfrowany_tekst="";
        for(int i=0;i<tekst.length();i++){
            if(tekst.charAt(i)>='A' && tekst.charAt(i)<='Z'){
                zaszyfrowany_tekst+=(char)((tekst.charAt(i)+3-'A')%26+'A'); //zamiana znaku według wzoru
            }
            if(tekst.charAt(i)>='a' && tekst.charAt(i)<='z'){
                zaszyfrowany_tekst+=(char)((tekst.charAt(i)+3-'a')%26+'a');//zamiana znaku według wzoru
            }
        }
        return zaszyfrowany_tekst;
    }
    public static String deszyfrowanie(String tekst){
        String zdeszyfrowany_tekst="";
        for(int i=0;i<tekst.length();i++){
            if(tekst.charAt(i)>='A' && tekst.charAt(i)<='Z'){
                zdeszyfrowany_tekst+=(char)('Z'-('Z'-tekst.charAt(i)+3)%26);//zamiana znaku według wzoru
            }
            if(tekst.charAt(i)>='a' && tekst.charAt(i)<='z'){
                zdeszyfrowany_tekst+=(char)('z'-('z'-tekst.charAt(i)+3)%26);//zamiana znaku według wzoru
            }
        }
        return zdeszyfrowany_tekst;
    }
    public static void main(String[] args) {
        // TODO code application logic here
        Scanner bufor=new Scanner(System.in);
        System.out.println("Wprowadź słowo do zaszyfrowania:");
        String tekst=bufor.nextLine();
        String zaszyfrowany_tekst=szyfrowanie(tekst);
        System.out.println("Zaszyfrowany tekst:"+zaszyfrowany_tekst);
        String zdeszyfrowany_tekst=deszyfrowanie(zaszyfrowany_tekst);
        System.out.println("Zdeszyfrowany tekst:"+zdeszyfrowany_tekst);
        
    }
    
}
