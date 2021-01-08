package application;

import java.io.File;

import java.util.Calendar;

import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;

public class bellSchedule{
	static boolean bellExit = true;
	static File breakSong = new File("resources/Tobu - Louder Now.mp3");
	static File startingSong = new File("resources/Tobu & Mangoo - Who Needs a Broken Heart.mp3");
	//static for now might need to change later on;
	static Media playBreakSong = new Media(breakSong.toURI().toString());
	static Media playStartingSong = new Media(startingSong.toURI().toString());
	
	static MediaPlayer breakBellSound = new MediaPlayer(playBreakSong);
	static MediaPlayer startingBellSound = new MediaPlayer(playStartingSong);
	
	public static void bellErrorMessage() {
		System.out.println("oi something went wrong while trying to play bell for 10 seconds");
	}
	
	public static void playBell(MediaPlayer bellSound) {
		MediaPlayer thisBellSound = bellSound;
		thisBellSound.play();
		try{
			Thread.sleep(10000);
		}
		catch(Exception e) {
			bellErrorMessage();
		}
		thisBellSound.stop();
	}
	Runnable run = () -> {
		Calendar date = Calendar.getInstance();
		
		//Run Check
		System.out.println("Today is: " + date.get(Calendar.DAY_OF_WEEK) + "The time is: " + date.get(Calendar.HOUR_OF_DAY) + ":" + date.get(Calendar.MINUTE));
		
		//Friday Schedule
		if(date.get(Calendar.DAY_OF_WEEK) == 6) {
			switch (date.get(Calendar.HOUR_OF_DAY)) {
				//8:10-8:15
				case 8: if(date.get(Calendar.MINUTE) == 10) {
					playBell(breakBellSound);
				}
				if(date.get(Calendar.MINUTE) == 15) {
					playBell(startingBellSound);
				}
				break;
				
				//9:20-9:25
				case 9: if(date.get(Calendar.MINUTE) == 20) {
					playBell(breakBellSound);
				}
				if(date.get(Calendar.HOUR_OF_DAY) == 9 && date.get(Calendar.MINUTE)== 25) {
					playBell(startingBellSound);
				}
				break;
				
				//10:30-10:45
				case 10: if(date.get(Calendar.MINUTE) == 30) {
					playBell(breakBellSound);
				}
				if(date.get(Calendar.MINUTE)== 45) {
					playBell(startingBellSound);
				}
				break;
				
				//11:50-11:55
				case 11: if(date.get(Calendar.MINUTE) == 50) {
					playBell(breakBellSound);
				}
				if(date.get(Calendar.MINUTE)== 55) {
					playBell(startingBellSound);
				}
				break;
			}
			//Other day schedule
		}else {
			switch (date.get(Calendar.HOUR_OF_DAY)) {
				//8:45-8:50
				case 8: if(date.get(Calendar.MINUTE) == 45) {
					playBell(breakBellSound);
				}
				if(date.get(Calendar.MINUTE) == 50) {
					playBell(startingBellSound);
				}
				break;
				
				//10:10-10:15
				case 10: if(date.get(Calendar.MINUTE) == 10) {
					playBell(breakBellSound);
				}
				if(date.get(Calendar.MINUTE) == 15) {
					playBell(startingBellSound);
				}
				break;
				
				//11:40
				case 11: if(date.get(Calendar.MINUTE) == 40) {
					playBell(breakBellSound);
				}
				break;
				
				//End of Lunch (12:20 - 12:40)
				case 12: if(date.get(Calendar.MINUTE) == 20) {
					playBell(breakBellSound);
				}
				if(date.get(Calendar.MINUTE) == 25) {
					playBell(startingBellSound);
				}
				break;
				
				//13:45-13:50 (1:45 - 1:50)
				case 13: if(date.get(Calendar.MINUTE) == 45) {
					playBell(breakBellSound);
				}
				if(date.get(Calendar.MINUTE) == 50) {
					playBell(startingBellSound);
				}
				break;
				
				//end
				case 15: if(date.get(Calendar.MINUTE) == 10) {
					playBell(breakBellSound);
				}
				break;
			}
		}
	};
	
	public static void stopBell() {
		System.out.println("Stopped");
		bellExit = true;
	}
	
	public static void startBell() {
		System.out.println("Started");
		bellExit = false;
	}
	
	public static Calendar checkCurrentTime() {
		Calendar currentTime = Calendar.getInstance();
		return currentTime;
	}
}
