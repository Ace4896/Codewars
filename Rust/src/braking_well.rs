const G: f64 = 9.81;
const T: f64 = 1.0;

fn dist(v: f64, mu: f64) -> f64 {
    // Convert v from km/hr to m/s
    let v = v * 1000.0 / 3600.0;

    // Reaction distance + braking distance
    (v * T) + (v * v) / (2.0 * mu * G)
}

fn speed(d: f64, mu: f64) -> f64 {
    // From the distance formula, we have:
    // d = (v * t) + (v * v) / (2.0 * mu * g)
    //
    // Re-arranging, we get:
    // v^2 + (2.0 * mu * g * t)v - (2.0 * mu * g * d) = 0;
    //
    // Then solve w/ quadratic formula (using positive solution)
    let two_mu_g = 2.0 * mu * G;

    // a = 1
    let b = two_mu_g * T;
    let c = -two_mu_g * d;
    let discriminant = b * b - 4.0 * c;
    let v_meters_per_sec = (-b + discriminant.sqrt()) / 2.0;
    v_meters_per_sec / 1000.0 * 3600.0
}

#[cfg(test)]
mod tests {
    use super::{dist, speed};
    use float_eq::float_eq;

    #[test]
    fn basic_tests_dist() {
        assert_float_equals(dist(144.0, 0.3), 311.83146449201496);
        assert_float_equals(dist(92.0, 0.5), 92.12909477605366);
    }

    #[test]
    fn basic_tests_speed() {
        assert_float_equals(speed(159.0, 0.8), 153.79671564846308);
        assert_float_equals(speed(164.0, 0.7), 147.91115701756493);
    }

    fn assert_float_equals(actual: f64, expected: f64) {
        let merr = 1.0e-12;
        let res =
            float_eq!(actual, expected, abs <= merr) || float_eq!(actual, expected, rmax <= merr);
        assert!(
            res,
            "Expected value must be near: {:e} but was:{:e}",
            expected, actual
        );
    }
}
