package application;

import java.util.Calendar;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.ScheduledFuture;
import java.util.concurrent.TimeUnit;

import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.stage.Stage;

import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.Button;
import javafx.scene.effect.DropShadow;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.GridPane;

public class Main extends Application {
	
	@Override
	public void start(Stage primaryStage) {
		try {
			DropShadow shadow = new DropShadow();
			
			Label onButtonLab = new Label("On/Off");
			Button onButton = new Button("On");
			onButton.addEventHandler(MouseEvent.MOUSE_ENTERED, 
				    new EventHandler<MouseEvent>() {
				        @Override public void handle(MouseEvent e) {
				            onButton.setEffect(shadow);
				        }
				});
			onButton.addEventHandler(MouseEvent.MOUSE_CLICKED,
					new EventHandler<MouseEvent>() {
				@Override public void handle(MouseEvent e) {
					if(onButton.getText() == "On") {
						onButton.setText("Off");
						onButtonLab.setText("The 20/20 feature is currently off");
						twentyTwenty.stopPlaying();
					}
					else {
						onButton.setText("On");
						onButtonLab.setText("The 20/20 feature is currently on");
						twentyTwenty.startPlaying();
					}

				}
			});
				onButton.addEventHandler(MouseEvent.MOUSE_EXITED, 
				    new EventHandler<MouseEvent>() {
				        @Override public void handle(MouseEvent e) {
				            onButton.setEffect(null);
				        }
				});
			
			Label bellScheduleLab = new Label("Schedule");
			Button bellScheduleButton = new Button("Off");
			bellScheduleButton.addEventHandler(MouseEvent.MOUSE_ENTERED, 
			    new EventHandler<MouseEvent>() {
			        @Override public void handle(MouseEvent e) {
			            bellScheduleButton.setEffect(shadow);
			        }
			});
			bellScheduleButton.addEventHandler(MouseEvent.MOUSE_CLICKED,
					new EventHandler<MouseEvent>() {
				@Override public void handle(MouseEvent e) {
					if(bellScheduleButton.getText() == "On") {
						bellScheduleButton.setText("Off");
						bellScheduleLab.setText("The bell schedule feature is currently off");
						bellSchedule.stopBell();
					}
					else {
						bellScheduleButton.setText("On");
						bellScheduleLab.setText("The bell schedule feature is currently on");
						bellSchedule.startBell();
					}

				}
			});
			bellScheduleButton.addEventHandler(MouseEvent.MOUSE_EXITED, 
			    new EventHandler<MouseEvent>() {
			        @Override public void handle(MouseEvent e) {
			            bellScheduleButton.setEffect(null);
			        }
			});
			
			
			GridPane root = new GridPane();
			
			root.addRow(0, onButtonLab,onButton);
			root.addRow(1, bellScheduleLab,bellScheduleButton);
			
			root.setHgap(10);
			root.setVgap(10);
			
			/*
			GridPane.setMargin(onButtonLab, new Insets(10, 10, 10, 10));
			GridPane.setMargin(bellScheduleLab, new Insets(10,10,10,10));
			*/
			
			Scene scene = new Scene(root,400,400);
			scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
			primaryStage.setScene(scene);
			primaryStage.setTitle("Twenty2 Java");

			primaryStage.show();
			
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
	
	public static void main(String[] args) {
		bellSchedule bellObj = new bellSchedule();
		
		Thread guiThread = new Thread(() -> {
			launch(args);
			System.out.println("guiThread started!");
		});
		guiThread.start();
		
		Thread musicPlayingThread = new Thread(() -> {
			twentyTwenty.twentyRule();
			System.out.println("twentyThread started!");
		});
		
		musicPlayingThread.start();
				
		Thread bellScheduleThread = new Thread(() -> {
			ScheduledExecutorService scheduler = Executors.newScheduledThreadPool(1);
			ScheduledFuture<?> delay = scheduler.scheduleAtFixedRate(bellObj.run, 0, 1, TimeUnit.MINUTES);
			//delay.schedule(bellSchedule::bellTimes, 60, TimeUnit.SECONDS);
			System.out.println("bellSchedule Started!!");
		});
		
		bellScheduleThread.start();

	}
}
