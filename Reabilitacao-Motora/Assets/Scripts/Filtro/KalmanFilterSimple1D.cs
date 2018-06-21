//http://habrahabr.ru/post/140274/
class KalmanFilterSimple1D
{
    public float X0 { get; private set; } // predicted state
    public float P0 { get; private set; } // predicted covariance

    public float F { get; private set; } // factor of real value to previous real value
    public float Q { get; private set; } // measurement noise
    public float H { get; private set; } // factor of measured value to real value
    public float R { get; private set; } // environment noise

    public float State { get; private set; }
    public float Covariance { get; private set; }

    public KalmanFilterSimple1D(float q, float r, float f = 1, float h = 1)
    {
        Q = q;
        R = r;
        F = f;
        H = h;
    }

    public void SetState(float state, float covariance)
    {
        State = state;
        Covariance = covariance;
    }

    public void Correct(float data)
    {
        //time update - prediction
        X0 = F * State;
        P0 = F * Covariance * F + Q;

        //measurement update - correction
        var K = H * P0 / (H * P0 * H + R);
        State = X0 + K * (data - H * X0);
        Covariance = (1 - K * H) * P0;
    }
}