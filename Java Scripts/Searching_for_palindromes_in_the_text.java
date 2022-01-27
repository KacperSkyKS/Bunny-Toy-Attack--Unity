/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package wyszukiwanie_palindromow_w_tekscie;

import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

/**
 *
 * @author Kacper
 */
public class Wyszukiwanie_palindromow_w_tekscie {

    /**
     * @param args the command line arguments
     */
        public static void wyszukiwanie(String tekst, int lewo, int prawo, Set<String> lista){
		// pętla trwa do momentu dopóki słowo z zakresu od lewo do prawo jest palindromem, lub dopóki któraś ze zmiennych nie wyjdzie poza zakres stringa
		while (lewo >= 0 && prawo < tekst.length() && tekst.charAt(lewo) == tekst.charAt(prawo))
		{
                    if(tekst.substring(lewo, prawo + 1).length()>1){ // uznałem że nie bede wpisywał do listy palindromów jednoznakowych
			lista.add(tekst.substring(lewo, prawo + 1));} // wzrucamy palindromy do listy
			lewo--; //zwiększamy zakres obu stron
			prawo++;
		}
	}
	public static void wszystkie_palindromy(String tekst)
	{
		Set<String> lista_palindromów = new HashSet(); //lista przechowująca nasze palindromy
                //na początku użyłem List<String>, ale to sprawiało że palindromy się powtarzały, więc stwierdziłem że użyję set żeby tylko unikalne palindromy były bez powtórek
                //jeśli tak miało byc z tym powtarzaniem to wystarczy żeby użyć List<String>
		for (int i = 0; i < tekst.length(); i++)
		{
			wyszukiwanie(tekst, i, i, lista_palindromów); //wyszukiwanie palindromów o nieparzystej długości, środek takiego palindromu to i
			wyszukiwanie(tekst, i, i + 1, lista_palindromów);//wyszukiwanie palindromów o parzystej długości, środek takiego palindromu to i oraz i+1
		}

                //Wyświetlenie palindromów
		System.out.print(lista_palindromów);
	}
    public static void main(String[] args) {
        // TODO code application logic here
        Scanner bufor=new Scanner(System.in);
        System.out.println("Wpisz ciąg tekstowy:");
        String tekst=bufor.nextLine();
        wszystkie_palindromy(tekst);
    }
}
