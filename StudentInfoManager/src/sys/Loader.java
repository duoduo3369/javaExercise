package sys;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Iterator;

import score.MathScore;
import score.SoftWareScore;
import statistic.Statistic;

public class Loader {
	private ArrayList lines;
	private BufferedReader input = new BufferedReader(new InputStreamReader(
			System.in));

	private void cls() {
		String enter = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
		System.out.println(enter);
	}

	private void pause() {
		try {
			System.out.println("\n������س���������");
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
			System.out.println("лл����ʹ��");
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
			while(studentBaseInfoManagerUi() != 0){
				
			}
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
		}

	}

	private void order() {
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
				System.out.println("\n\tѡ���Ŀ��");
				System.out.println("1����ѧ");
				System.out.println("2����������");
				System.out.println("0���������˵�");
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
			// input.close();
		} catch (IOException e) {
			System.out.println("������������,�����������롣");
		} catch (NumberFormatException e) {
			System.out.println("N:������������,�����������롣");
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

			System.out.println("\n\tѡ���Ŀ��");
			System.out.println("1����ѧ");
			System.out.println("2����������");

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
			// input.close();
		} catch (IOException e) {
			System.out.println("������������,�����������롣");
		} catch (NumberFormatException e) {
			System.out.println("N:������������,�����������롣");
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

		System.out.println("\n\tƽ���ɼ�");
		statistic.statisticMathScore.printAverageScore();
		statistic.statisticSoftWareScore.printAverageScore();
	}

	private int initUi() {

		lines = new ArrayList();
		lines.add("\n\t���˵�\n");
		lines.add("1��ѧ��������Ϣ����");
		lines.add("2����Ŀƽ���ɼ���ѯ");
		lines.add("3����Ŀ�ɼ�����������ѯ(��ͼ����״ͼ)");
		lines.add("4�����տ�Ŀ�ɼ�����");
		lines.add("0���˳�����");
		lines.add("\n��ѡ��");
		Iterator iter = lines.iterator();

		while (iter.hasNext()) {
			System.out.println(iter.next());
		}
		String line;
		int cmd = -1;
		try {
			line = input.readLine();
			// System.out.println("line "+line);
			cmd = Integer.parseInt(line);
			// input.close();
		} catch (NumberFormatException e) {
			System.out.println("N:������������,�����������롣");
		} catch (IOException e) {
			System.out.println("I:������������,������������,�����뷶Χ��0~5�ڵ�����!");
		}
		return cmd;
	}

	private int studentBaseInfoManagerUi() {
		lines = new ArrayList();
		lines.add("\n\tѧ��������Ϣ����\n");
		lines.add("1������ѧ����Ϣ");
		lines.add("2��ɾ��ѧ����Ϣ");
		lines.add("3���޸�ѧ����Ϣ");
		lines.add("4����ѧ�Ų�ѯѧ������ɼ�");
		lines.add("0�������˵�");
		lines.add("\n��ѡ��");
		
		boolean cmdInFlag = true;
		int cmd = 0;
		while (cmdInFlag) {
			Iterator iter = lines.iterator();
			while (iter.hasNext()) {
				System.out.println(iter.next());
			}
			try {
				String line = input.readLine();
				cmd = Integer.parseInt(line);
				if (cmd < 0 || (cmd > 4)) {
					System.out.println("������������,�����������롣");
					continue;
				}
				cmdInFlag = false;
				// input.reset();

			} catch (IOException e) {
			} catch (NumberFormatException e) {
				System.out.println("������������,�����������롣");
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
			System.out.println("\n\tѧ����Ϣ¼�룺");
			try {
				System.out.println("������ѧ�ţ�");
				no = input.readLine();
				Student student = studentManager.getStudent(no);
				if (student != null) {
					System.out.println("��ѧ��ѧ����Ϣ��¼�롣");
					break;
				}
				System.out.println("������������");
				name = input.readLine();
				student = new Student(no, name);
				boolean majorflag = true;
				while (majorflag) {
					System.out.println("\n\t��ѡ���Ŀ��");
					System.out.println("1����ѧ�ɼ�����");
					System.out.println("2���������̳ɼ�����");
					System.out.println("0��ȷ��������ѧ���ɼ�");
					// System.out.println("-1�������˴γɼ�¼��");
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
						System.out.println("��������ѧ�ɼ���");
						temp = input.readLine();
						score = Double.parseDouble(temp);
						MathScore ms = new MathScore(score, student);
						break;
					}
					case 2: {
						System.out.println("�������������̳ɼ���");
						temp = input.readLine();
						score = Double.parseDouble(temp);
						SoftWareScore ms = new SoftWareScore(score, student);
						break;
					}
					}

				}
				// input.reset();
			} catch (NumberFormatException e) {
				System.out.println("�������,�����ԡ�");
			} catch (IOException e) {
				System.out.println("�������,�����ԡ�");
				// e.printStackTrace();
			}

			break;
		}

		case 2: {

			String no;
			System.out.println("\n\tɾ��ѧ����Ϣ");
			try {
				System.out.println("������ѧ�ţ�");
				no = input.readLine();
				Student student = studentManager.getStudent(no);
				if (student == null) {
					System.out.println("û�����ѧ�ŵ�ѧ����Ϣ��");
					break;
				}
				studentManager.deleteStudent(no);
				SaveStudentInfo.save(studentManager,false);
				System.out.println("��ɾ����");
				// input.reset();
			} catch (IOException e) {
				System.out.println("�������,�����ԡ�");
			}
			break;

		}
		case 3: {

			String no;
			double score;
			int major;
			System.out.println("\n\t�޸�ѧ����Ϣ��");
			try {
				System.out.println("������ѧ�ţ�");
				no = input.readLine();
				Student student = studentManager.getStudent(no);
				if (student == null) {
					System.out.println("û�����ѧ�ŵ�ѧ����Ϣ��");
					break;
				}
				boolean majorflag = true;
				while (majorflag) {
					System.out.println("\n\t��ѡ���޸Ŀ�Ŀ��");
					System.out.println("1����ѧ�ɼ��޸�");
					System.out.println("2���������̳ɼ��޸�");
					System.out.println("0��ȷ��������ѧ���ɼ�");
					// System.out.println("-1�������˴γɼ�¼��");
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
						System.out.println("��������ѧ�ɼ���");
						temp = input.readLine();
						score = Double.parseDouble(temp);
						MathScore ms = new MathScore(score, student);
						studentManager.changeStudentMajorScore(no, ms);
						break;
					}
					case 2: {
						System.out.println("�������������̳ɼ���");
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
				// System.out.println("�������,�����ԡ�");
				// e.printStackTrace();
			}
			break;
		}
		case 4: {
			System.out.println("\n\t��ѧ�Ų�ѯѧ������ɼ�");
			// BufferedReader inputStudent = new BufferedReader(
			// new InputStreamReader(System.in));
			String no;
			System.out.println("������ѧ�ţ�");
			try {
				no = input.readLine();
				Student student = studentManager.getStudent(no);
				if (student == null) {
					System.out.println("û�����ѧ�ŵ�ѧ����Ϣ��");
					break;
				} else {
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
			// System.out.println("������������,�����������롣");
			// studentBaseInfoManagerUi();
			break;
		}
		}
		return cmd;

	}

}