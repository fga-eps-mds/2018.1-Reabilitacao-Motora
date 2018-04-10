#include <bits/stdc++.h>

using namespace std;


int main () {
	srand (time(NULL));
	
	ofstream mf ("points.txt");
	if (mf.is_open()) {
		float x = 0, y = 0;
		for (; x < 7.5; x += 0.02) {
			//float y = static_cast <float> (rand()) / (static_cast <float> (RAND_MAX/180));
			y += 0.48;
			string z = to_string(x) + " " + to_string(y) + "\n";
			mf << z;
		}

		for (; x < 15; x += 0.02) {
			//float y = static_cast <float> (rand()) / (static_cast <float> (RAND_MAX/180));
			y -= 0.48;
			string z = to_string(x) + " " + to_string(y) + "\n";
			mf << z;
		}
		mf.close();
	}

}