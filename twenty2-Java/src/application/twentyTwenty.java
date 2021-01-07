package application;

import java.io.File;

import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;

public class twentyTwenty {
	static boolean exit = false;
	
	public static void twentyRule() {
		File musicLocation = new File("resources/Tobu - Louder Now.mp3");
		Media playMusic = new Media(musicLocation.toURI().toString());
		
		MediaPlayer play = new MediaPlayer(playMusic);
		play.play();
		try {Thread.sleep(2000);}
		catch(Exception e){
			System.out.println("Test failed...");
			//text(0,0, "something went wrong");
		}
		play.stop();
		
		int breakTime = 20 * 1000;
		int funTime = 20 * 1000 * 60;
		
		while(exit == false) {
			try {Thread.sleep(breakTime);}catch(Exception e) {System.out.println("Something went wrong...");}
			play.stop();
			try {Thread.sleep(funTime);}catch(Exception f) {System.out.println("something went wrong 2...");}
			play.play();
		
		}
	}
	public static void stopPlaying() {
		exit = true;
	}
	public static void startPlaying() {
		exit = false;
	}
}
