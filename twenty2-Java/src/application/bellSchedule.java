package application;

import java.io.File;

import java.util.Calendar;

import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;

public class bellSchedule {
	static boolean bellExit = true;
	
	public static void bellTimes() {
		File breakSong = new File("resources/Tobu - Louder Now.mp3");
		File startingSong = new File("resources/Tobu & Mangoo - Who Needs a Broken Heart.mp3");
		Media playBreakSong = new Media(breakSong.toURI().toString());
		Media playStartingSong = new Media(startingSong.toURI().toString());
		
		MediaPlayer breakBellSound = new MediaPlayer(playBreakSong);
		MediaPlayer startingBellSound = new MediaPlayer(playStartingSong);
		
		Calendar date = Calendar.getInstance();
		
		//Run Check
		//System.out.println("Today is: " + date.get(Calendar.DAY_OF_WEEK) + "The time is: " + date.get(Calendar.HOUR_OF_DAY) + ":" + date.get(Calendar.MINUTE));
		
		//Friday Schedule
		if(date.get(Calendar.DAY_OF_WEEK) == 6) {
			
			//8:20-8:15
			if(date.get(Calendar.HOUR_OF_DAY) == 8 && date.get(Calendar.MINUTE) == 10) {
				breakBellSound.play();
				try{Thread.sleep(10000);}catch(Exception e) {System.out.println("oi something went wrong trying to right the bell");}
				breakBellSound.stop();
			}
			if(date.get(Calendar.HOUR_OF_DAY) == 8 && date.get(Calendar.MINUTE)== 15) {
				startingBellSound.play();
				try {Thread.sleep(4000);}catch(Exception e) {System.out.println("oi something went wrong trying to ring the starting bell");}
				startingBellSound.stop();
			}
			
			//9:20-9:25
			if(date.get(Calendar.HOUR_OF_DAY) == 9 && date.get(Calendar.MINUTE) == 20) {
				breakBellSound.play();
				try{Thread.sleep(10000);}catch(Exception e) {System.out.println("oi something went wrong trying to right the bell");}
				breakBellSound.stop();
			}
			if(date.get(Calendar.HOUR_OF_DAY) == 9 && date.get(Calendar.MINUTE)== 25) {
				startingBellSound.play();
				try {Thread.sleep(4000);}catch(Exception e) {System.out.println("oi something went wrong trying to ring the starting bell");}
				startingBellSound.stop();
			}
			
			//10:30-10:45
			if(date.get(Calendar.HOUR_OF_DAY) == 10 && date.get(Calendar.MINUTE) == 30) {
				breakBellSound.play();
				try{Thread.sleep(10000);}catch(Exception e) {System.out.println("oi something went wrong trying to right the bell");}
				breakBellSound.stop();
			}
			if(date.get(Calendar.HOUR_OF_DAY) == 10 && date.get(Calendar.MINUTE)== 45) {
				startingBellSound.play();
				try {Thread.sleep(4000);}catch(Exception e) {System.out.println("oi something went wrong trying to ring the starting bell");}
				startingBellSound.stop();
			}
			
			
			//11:50-11:55
			if(date.get(Calendar.HOUR_OF_DAY) == 11 && date.get(Calendar.MINUTE) == 50) {
				breakBellSound.play();
				try{Thread.sleep(10000);}catch(Exception e) {System.out.println("oi something went wrong trying to right the bell");}
				breakBellSound.stop();
			}
			if(date.get(Calendar.HOUR_OF_DAY) == 11 && date.get(Calendar.MINUTE)== 55) {
				startingBellSound.play();
				try {Thread.sleep(4000);}catch(Exception e) {System.out.println("oi something went wrong trying to ring the starting bell");}
				startingBellSound.stop();
			}
			
			//Other day schedule
		}else {
			//8:45-8:50
			if(date.get(Calendar.HOUR_OF_DAY) == 8 && date.get(Calendar.MINUTE) == 45) {
				breakBellSound.play();
				try{Thread.sleep(10000);}catch(Exception e) {System.out.println("oi something went wrong trying to right the bell");}
				breakBellSound.stop();
			}
			if(date.get(Calendar.HOUR_OF_DAY) == 8 && date.get(Calendar.MINUTE)== 50) {
				startingBellSound.play();
				try {Thread.sleep(4000);}catch(Exception e) {System.out.println("oi something went wrong trying to ring the starting bell");}
				startingBellSound.stop();
			}
			
			//10:10-10:15
			if(date.get(Calendar.HOUR_OF_DAY) == 10 && date.get(Calendar.MINUTE) == 10) {
				breakBellSound.play();
				try{Thread.sleep(10000);}catch(Exception e) {System.out.println("oi something went wrong trying to right the bell");}
				breakBellSound.stop();
			}
			if(date.get(Calendar.HOUR_OF_DAY) == 10 && date.get(Calendar.MINUTE)== 15) {
				startingBellSound.play();
				try {Thread.sleep(4000);}catch(Exception e) {System.out.println("oi something went wrong trying to ring the starting bell");}
				startingBellSound.stop();
			}
			
			//11:40-12:25
			if(date.get(Calendar.HOUR_OF_DAY) == 11 && date.get(Calendar.MINUTE) == 40) {
				breakBellSound.play();
				try{Thread.sleep(10000);}catch(Exception e) {System.out.println("oi something went wrong trying to right the bell");}
				breakBellSound.stop();
			}
			if(date.get(Calendar.HOUR_OF_DAY) == 12 && date.get(Calendar.MINUTE)== 25) {
				startingBellSound.play();
				try {Thread.sleep(4000);}catch(Exception e) {System.out.println("oi something went wrong trying to ring the starting bell");}
				startingBellSound.stop();
			}
			
			
			//13:45-13:50
			if(date.get(Calendar.HOUR_OF_DAY) == 13 && date.get(Calendar.MINUTE) == 45) {
				breakBellSound.play();
				try{Thread.sleep(10000);}catch(Exception e) {System.out.println("oi something went wrong trying to right the bell");}
				breakBellSound.stop();
			}
			if(date.get(Calendar.HOUR_OF_DAY) == 13 && date.get(Calendar.MINUTE)== 50) {
				startingBellSound.play();
				try {Thread.sleep(4000);}catch(Exception e) {System.out.println("oi something went wrong trying to ring the starting bell");}
				startingBellSound.stop();
			}
		}
	}
	
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
