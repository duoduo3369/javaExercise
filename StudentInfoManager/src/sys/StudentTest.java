package sys;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Iterator;

public class StudentTest {
	private ArrayList lines;
	private BufferedReader input =new BufferedReader(new InputStreamReader(
			System.in));
	private void cls() {
		String enter = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
		System.out.println(enter);
	}

	private void pause() {
		try {
			System.out.println("\n请输入回车键继续：");
			input.readLine();
			input.close();
			input = null;
		} catch (IOException e) {
		}
	}

	public void run() {
		
		while (true) {
			glue();
		}
	}

	private void glue() {
		int cmd = initUi();
		switch (cmd) {
		case 0: {
			System.out.println("谢谢您的使用");
			try {
				input.close();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			System.exit(0);
			break;
		}
		case 1: {
			studentBaseInfoManagerUi();
			break;
		}
		case 2: {
			averageScore();
			break;
		}
		case 3: {
			chart();
			break;
		}
		case 4: {
			order();
			break;
		}

		default: {
			System.out.println("D:您的输入有误,请检查您的输入。");
			break;
		}

		}

	}

	private void order(){
		StudentManager studentManager;
		try {
			studentManager = ReadStudentInfo.read();
		} catch (FileNotFoundException e1) {
			studentManager = new StudentManager();
		}
		Statistic statistic = new Statistic(studentManager);
		statistic.statistic();
		// BufferedReader inputMajor = new BufferedReader(
		// new InputStreamReader(System.in));
		String temp = "0";
		int major;

		try {
			boolean majorflag = true;
			
			while (majorflag) {
				System.out.println("\n\t选择科目：");
				System.out.println("1、数学");
				System.out.println("2、软件工程");
				System.out.println("0、返回主菜单");
				temp = input.readLine();
				major = Integer.parseInt(temp);
				switch (major) {
				case 0: {
					majorflag = false;
					break;
				}
				case 1: {
					statistic.statisticMathScore.printStudent();
					break;
				}
				case 2: {
					statistic.statisticSoftWareScore.printStudent();
					break;
				}
				}

			}
			//input.close();
		} catch (IOException e) {
			System.out.println("您的输入有误,请检查您的输入。");
		} catch (NumberFormatException e) {
			System.out.println("N:您的输入有误,请检查您的输入。");
		}
	}
	private void chart() {
		StudentManager studentManager;
		try {
			studentManager = ReadStudentInfo.read();
		} catch (FileNotFoundException e1) {
			studentManager = new StudentManager();
		}
		Statistic statistic = new Statistic(studentManager);
		statistic.statistic();

		String temp;
		int major;
		try {

			System.out.println("\n\t选择科目：");
			System.out.println("1、数学");
			System.out.println("2、软件工程");

			temp = input.readLine();
			major = Integer.parseInt(temp);
			switch (major) {

			case 1: {
				statistic.statisticMathScore.showBarChart();
				statistic.statisticMathScore.showPieChart();
				break;
			}
			case 2: {
				statistic.statisticSoftWareScore.showBarChart();
				statistic.statisticSoftWareScore.showPieChart();
				break;
			}

			}
			//input.close();
		} catch (IOException e) {
			System.out.println("您的输入有误,请检查您的输入。");
		} catch (NumberFormatException e) {
			System.out.println("N:您的输入有误,请检查您的输入。");
		}
	}

	private void averageScore() {
		StudentManager studentManager;
		try {
			studentManager = ReadStudentInfo.read();
		} catch (FileNotFoundException e1) {
			studentManager = new StudentManager();
		}
		Statistic statistic = new Statistic(studentManager);
		statistic.statistic();

		System.out.println("\n\t平均成绩");
		statistic.statisticMathScore.printAverageScore();
		statistic.statisticSoftWareScore.printAverageScore();
	}

	private int initUi() {

		lines = new ArrayList();
		lines.add("\n\t主菜单\n");
		lines.add("1、学生基本信息管理");
		lines.add("2、科目平均成绩查询");
		lines.add("3、科目成绩分析比例查询(饼图、柱状图)");
		lines.add("4、按照科目成绩排名");
		lines.add("0、退出程序");
		lines.add("\n请选择：");
		Iterator iter = lines.iterator();

		while (iter.hasNext()) {
			System.out.println(iter.next());
		}
		String line;
		int cmd = 0;
		try {
			line = input.readLine();
			// System.out.println("line "+line);
			cmd = Integer.parseInt(line);
			//input.close();
		} catch (NumberFormatException e) {
			System.out.println("N:您的输入有误,请检查您的输入。");
		} catch (IOException e) {
			System.out.println("I:您的输入有误,请检查您的输入,请输入范围在0~5内的整数!");
		}
		return cmd;
	}

	private void studentBaseInfoManagerUi() {
		while (true) {
			lines = new ArrayList();
			lines.add("\n\t学生基本信息管理\n");
			lines.add("1、增加学生信息");
			lines.add("2、删除学生信息");
			lines.add("3、修改学生信息");
			lines.add("4、按学号查询学生及其成绩");
			lines.add("0、回主菜单");
			lines.add("\n请选择：");
			Iterator iter = lines.iterator();
			while (iter.hasNext()) {
				System.out.println(iter.next());
			}
			boolean cmdInFlag = true;
			int cmd = 0;
			while (cmdInFlag) {
				try {
					String line = input.readLine();
					cmd = Integer.parseInt(line);
					System.out.println(cmd);
					if (cmd < 0 || (cmd > 4)) {
						System.out.println("您的输入有误,请检查您的输入。");
						continue;
					}
					cmdInFlag = false;
					// input.reset();

				} catch (IOException e) {
				} catch (NumberFormatException e) {
					System.out.println("您的输入有误,请检查您的输入。");
				}
			}
			StudentManager studentManager;
			try {
				studentManager = ReadStudentInfo.read();
			} catch (FileNotFoundException e1) {
				studentManager = new StudentManager();
			}
			switch (cmd) {

			case 1: {
				
				String no;
				String name;
				double score;
				int major;
				System.out.println("\n\t学生信息录入：");
				try {
					System.out.println("请输入学号：");
					no = input.readLine();
					Student student  = studentManager.getStudent(no);
					if(student != null){
						System.out.println("该学号学生信息已录入。");
						break;
					}
					System.out.println("\n请输入姓名：");
					name = input.readLine();
					student = new Student(no, name);
					boolean majorflag = true;
					while (majorflag) {
						System.out.println("\n\t请选择科目：");
						System.out.println("1、数学成绩输入");
						System.out.println("2、软件工程成绩输入");
						System.out.println("0、确定并保存学生成绩");
						// System.out.println("-1、放弃此次成绩录入");
						String temp = input.readLine();
						major = Integer.parseInt(temp);
						switch (major) {
						case -1: {
							majorflag = false;
							break;
						}
						case 0: {
							studentManager.addStudent(student);
							SaveStudentInfo.save(studentManager);
							majorflag = false;
							break;
						}
						case 1: {
							System.out.println("请输入数学成绩：");
							temp = input.readLine();
							score = Double.parseDouble(temp);
							MathScore ms = new MathScore(score, student);
							break;
						}
						case 2: {
							System.out.println("请输入软件工程成绩：");
							temp = input.readLine();
							score = Double.parseDouble(temp);
							SoftWareScore ms = new SoftWareScore(score, student);
							break;
						}
						}

					}
					// input.reset();
				} catch (IOException e) {
					System.out.println("输入错误,请重试。");
					// e.printStackTrace();
				}

				break;
			}

			case 2: {
				
				String no;
				System.out.println("\n\t删除学生信息");
				try {
					System.out.println("请输入学号：");
					no = input.readLine();
					Student student = studentManager.getStudent(no);
					if(student == null){
						System.out.println("没有这个学号的学生信息。");
						break;
					}
					studentManager.deleteStudent(no);
					SaveStudentInfo.save(studentManager);
					System.out.println("已删除。");
					// input.reset();
				} catch (IOException e) {
					System.out.println("输入错误,请重试。");
				}
				break;

			}
			case 3: {
				
				String no;
				double score;
				int major;
				System.out.println("\n\t修改学生信息：");
				try {
					System.out.println("请输入学号：");
					no = input.readLine();
					Student student = studentManager.getStudent(no);
					if(student == null){
						System.out.println("没有这个学号的学生信息。");
						break;
					}
					boolean majorflag = true;
					while (majorflag) {
						System.out.println("\n\t请选择修改科目：");
						System.out.println("1、数学成绩修改");
						System.out.println("2、软件工程成绩修改");
						System.out.println("0、确定并保存学生成绩");
						// System.out.println("-1、放弃此次成绩录入");
						String temp = input.readLine();
						major = Integer.parseInt(temp);
						switch (major) {
						case -1: {
							majorflag = false;
							break;
						}
						case 0: {
							SaveStudentInfo.save(studentManager);
							majorflag = false;
							break;
						}
						case 1: {
							System.out.println("请输入数学成绩：");
							temp = input.readLine();
							score = Double.parseDouble(temp);
							MathScore ms = new MathScore(score, student);
							studentManager.changeStudentMajorScore(no, ms);
							break;
						}
						case 2: {
							System.out.println("请输入软件工程成绩：");
							temp = input.readLine();
							score = Double.parseDouble(temp);
							SoftWareScore ms = new SoftWareScore(score, student);
							studentManager.changeStudentMajorScore(no, ms);
							break;
						}
						}

					}
					// input.reset();
				} catch (IOException e) {
					// System.out.println("输入错误,请重试。");
					// e.printStackTrace();
				}
				break;
			}
			case 4: {
				System.out.println("\n\t按学号查询学生及其成绩");
				// BufferedReader inputStudent = new BufferedReader(
				// new InputStreamReader(System.in));
				String no;
				System.out.println("请输入学号：");
				try {
					no = input.readLine();
					Student student = studentManager.getStudent(no);
					if(student == null){
						System.out.println("没有这个学号的学生信息。");
						break;
					}else{
						System.out.println(student);
						student.printMajorScores();
					}
					
				} catch (IOException e) {
					// e.printStackTrace();
				}

				break;
			}
			case 0: {
				break;
			}
			default: {
				// System.out.println("您的输入有误,请检查您的输入。");
				// studentBaseInfoManagerUi();
				break;
			}
			}
			if (cmd == 0) {
				
				break;
			}
		}
	}

	public static void main(String[] args) {
		StudentTest st = new StudentTest();
		st.run();
		/*
		 * StudentManager studentManager = new StudentManager(); Student a = new
		 * Student("101", "李广"); Student b = new Student("102", "夏侯渊"); Student
		 * c = new Student("103", "张颌"); Student a1 = new Student("104", "abc");
		 * Student b1 = new Student("105", "c"); Student c1 = new Student("106",
		 * "bc"); Student d1 = new Student("107", "bc");
		 * 
		 * MathScore ms = new MathScore(0, a); MathScore ms2 = new MathScore(12,
		 * b); MathScore ms3 = new MathScore(90.1, c); MathScore msa = new
		 * MathScore(80, a1); MathScore msa1 = new MathScore(75, b1); MathScore
		 * msb1 = new MathScore(62, c1); MathScore msc1 = new MathScore(43, d1);
		 * SoftWareScore ss = new SoftWareScore(79, a);
		 * 
		 * a.changeMajorScore(msa); studentManager.addStudent(a);
		 * studentManager.addStudent(b); studentManager.addStudent(c);
		 * studentManager.addStudent(a1); studentManager.addStudent(b1);
		 * studentManager.addStudent(c1); studentManager.addStudent(d1);
		 * 
		 * SaveStudentInfo.save(studentManager); StudentManager sm2 =
		 * ReadStudentInfo.read(); sm2.printAllStudent(); Student liguang =
		 * sm2.getStudent("101"); sm2.changeStudentMajorScore("101", new
		 * MathScore(91.2, liguang)); sm2.getStudent("101").printMajorScores();
		 * Statistic statistic = new Statistic(studentManager);
		 * statistic.statistic();
		 */
	}
}
