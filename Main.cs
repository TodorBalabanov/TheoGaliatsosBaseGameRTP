using System;

namespace TheoGaliatsosBaseGameRTP
{
	class MainClass
	{
		private static ulong[][] paytable = {
			new ulong[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			new ulong[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			new ulong[]{0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0},
			new ulong[]{0,0,0,100,50,50,20,20,20,20,0,0,0,0,0,10,0,0,},
			new ulong[]{0,0,0,1000,200,200,50,50,50,50,0,0,0,0,0,50,0,0},
			new ulong[]{0,0,0,5000,500,500,200,200,200,200,0,0,0,0,0,250,0,0},
		};
		
		private static int[][] reels = {
			new int[]{8,8,8,9,9,9,8,8,15,4,4,3,4,6,6,6,3,6,7,7,7,5,7,5,5},
			new int[]{7,7,7,4,7,4,4,8,3,8,8,8,5,5,3,5,9,9,9,9,15,6,6,6,6},
			new int[]{6,5,6,6,6,4,4,9,4,8,8,8,3,8,9,9,9,15,7,7,7,3,7,5,5},
			new int[]{6,6,6,5,5,3,7,7,7,7,3,7,6,6,15,4,4,8,8,8,9,8,9,9,9},
			new int[]{6,6,8,3,9,9,9,4,4,3,6,6,6,8,8,8,5,5,7,15,7,7,7,15,7},
		};
		
		private static int[][] extendedReels = new int[reels.Length][];
		static MainClass() {
			for(int i=0;i<reels.Length; i++) {
				extendedReels[i] = new int[reels[i].Length+2];
				for(int j=0; j<extendedReels[i].Length; j++) {
					extendedReels[i][j] = reels[i][j%reels[i].Length];
				}
			}
		}

		private static ulong totalNumberOfCombinations = (ulong)reels[0].Length * (ulong)reels[1].Length * (ulong)reels[2].Length * (ulong)reels[3].Length * (ulong)reels[4].Length;

		private static ulong[][] hits = {
			new ulong[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			new ulong[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			new ulong[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			new ulong[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			new ulong[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			new ulong[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		};

		public static void Main (string[] args){
			Console.WriteLine( totalNumberOfCombinations );

			int a = -1;
			int b = -1;
			int c = -1;
			int d = -1;
			int e = -1;

			int s0 = 0;
			int s1 = 0;
			int s2 = 0;
			int s3 = 0;
			int s4 = 0;
			
			int number = 0;

			for (e = 0; e < reels[4].Length; e++) {
				Console.WriteLine();
				Console.WriteLine((100.0D*e/reels[4].Length) + "%");

				s4 = 0;
				if(extendedReels[4][e] == 15) {
					s4++;	
				}
				if(extendedReels[4][e+1] == 15) {
					s4++;	
				}
				if(extendedReels[4][e+2] == 15) {
					s4++;
				}

				for (d = 0; d < reels[3].Length; d++) {
					Console.Write("=");
					
					s3 = 0;
					if(extendedReels[3][d] == 15) {
						s3++;	
					}
					if(extendedReels[3][d+1] == 15) {
						s3++;	
					}
					if(extendedReels[3][d+2] == 15) {
						s3++;	
					}

					for (c = 0; c < reels[2].Length; c++) {

						s2 = 0;
						if(extendedReels[2][c] == 15) {
							s2++;	
						}
						if(extendedReels[2][c+1] == 15) {
							s2++;	
						}
						if(extendedReels[2][c+2] == 15) {
							s2++;	
						}
						
						for (b = 0; b < reels[1].Length; b++) {

							s1 = 0;
							if(extendedReels[1][b] == 15) {
								s1++;	
							}
							if(extendedReels[1][b+1] == 15) {
								s1++;	
							}
							if(extendedReels[1][b+2] == 15) {
								s1++;	
							}

							for (a = 0; a < reels[0].Length; a++) {

								s0 = 0;
								if(extendedReels[0][a] == 15) {
									s0++;	
								}
								if(extendedReels[0][a+1] == 15) {
									s0++;	
								}
								if(extendedReels[0][a+2] == 15) {
									s0++;	
								}

								/*
								 * Use coin win without denomination.
								 */
								switch(s0+s1+s2+s3+s4) {
									case 3:
									hits[3][15]++;
									break;
								
									case 4:
									hits[4][15]++;
									break;
								
									case 5:
									hits[5][15]++;
									break;
								}

								/*
								 * Scatters do not form combinatoin.
								 */
								if(extendedReels[0][a+1] == 15) {
									continue;
								}

								number = 1;
								//multiplier = 1;
								//if(reels[0][a] == 13 && multiplier<1) {
									//multiplier = 1;
								//} else if(reels[0][a] == 14 && multiplier<2) {
									//multiplier = 2;
								//} else if(reels[0][a] == 15 && multiplier<3) {
									//multiplier = 3;
								//} else if(reels[0][a] == 16 && multiplier<5) {
									//multiplier = 5;
								//}

								if(extendedReels[0][a+1] == extendedReels[1][b+1] /*|| extendedReels[1][b+1]==13 || extendedReels[1][b+1]==14 || extendedReels[1][b+1]==15 || extendedReels[1][b+1]==16*/) {
									number = 2;
									//if(reels[1][b] == 13 && multiplier<1) {
										//multiplier = 1;
									//} else if(reels[1][b] == 14 && multiplier<2) {
										//multiplier = 2;
									//} else if(reels[1][b] == 15 && multiplier<3) {
										//multiplier = 3;
									//} else if(reels[1][b] == 16 && multiplier<5) {
										//multiplier = 5;
									//}

									if(extendedReels[0][a+1] == extendedReels[2][c+1] /*|| extendedReels[2][c+1]==13 || extendedReels[2][c+1]==14 || extendedReels[2][c+1]==15 || extendedReels[2][c+1]==16*/) {
										number = 3;
										//if(reels[2][c] == 13 && multiplier<1) {
											//multiplier = 1;
										//} else if(reels[2][c] == 14 && multiplier<2) {
											//multiplier = 2;
										//} else if(reels[2][c] == 15 && multiplier<3) {
											//multiplier = 3;
										//} else if(reels[2][c] == 16 && multiplier<5) {
											//multiplier = 5;
										//}
										
										if(extendedReels[0][a+1] == extendedReels[3][d+1] /*|| extendedReels[3][d+1]==13 || extendedReels[3][d+1]==14 || extendedReels[3][d+1]==15 || extendedReels[3][d+1]==16*/) {
											number = 4;
											//if(reels[3][d] == 13 && multiplier<1) {
												//multiplier = 1;
											//} else if(reels[3][d] == 14 && multiplier<2) {
												//multiplier = 2;
											//} else if(reels[3][d] == 15 && multiplier<3) {
												//multiplier = 3;
											//} else if(reels[3][d] == 16 && multiplier<5) {
												//multiplier = 5;
											//}
											
											if(extendedReels[0][a] == extendedReels[4][e+1] /*|| extendedReels[4][e+1]==13 || extendedReels[4][e+1]==14 || extendedReels[4][e+1]==15 || extendedReels[4][e+1]==16*/) {
												number = 5;
												//if(reels[4][e] == 13 && multiplier<1) {
													//multiplier = 1;
												//} else if(reels[4][e] == 14 && multiplier<2) {
													//multiplier = 2;
												//} else if(reels[4][e] == 15 && multiplier<3) {
													//multiplier = 3;
												//} else if(reels[4][e] == 16 && multiplier<5) {
													//multiplier = 5;
												//}												
											}
										}
									}
								}

								hits[number][extendedReels[0][a+1]]++;
								//won += paytable[number][reels[0][a]]*multiplier;
							}
						}
					}
				}
			}

			Console.WriteLine();
			for(int i=0; i<hits.Length; i++) {
				for(int j=0; j<hits[i].Length; j++) {
					Console.Write( hits[i][j] + "\t" );
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			for(int i=0; i<paytable.Length; i++) {
				for(int j=0; j<paytable[i].Length; j++) {
					Console.Write( paytable[i][j] + "\t" );
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			for(int i=0; i<paytable.Length&&i<hits.Length; i++) {
				for(int j=0; j<paytable[i].Length&&j<paytable[i].Length; j++) {
					Console.Write( (hits[i][j]*(ulong)paytable[i][j]) + "\t" );
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			for(int i=0; i<hits.Length; i++) {
				for(int j=0; j<hits[i].Length; j++) {
					Console.Write( (double)hits[i][j]/totalNumberOfCombinations + "\t" );
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			double rtp = 0.0;
			for(int i=0; i<paytable.Length&&i<hits.Length; i++) {
				for(int j=0; j<paytable[i].Length&&j<hits[i].Length; j++) {
					rtp += (double)hits[i][j]/totalNumberOfCombinations*(double)paytable[i][j];
					Console.Write( (double)hits[i][j]/totalNumberOfCombinations*(double)paytable[i][j] + "\t" );
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			
			Console.WriteLine();
			Console.WriteLine( totalNumberOfCombinations );

			Console.WriteLine();
			Console.WriteLine( rtp );

			//Console.WriteLine();
			//Console.WriteLine( won/(double)totalNumberOfCombinations );
		}
	}
}
