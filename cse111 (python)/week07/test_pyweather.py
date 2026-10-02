from pytest import approx
import pytest
from pyweather import *

def test_get_coordinates():
    assert get_coordinates("Tokyo") == (35.6762, 139.6503)
    assert get_coordinates("Delhi") == (28.6139, 77.2090)
    assert get_coordinates("Sao Paulo") == (-23.5505, -46.6333)
    assert get_coordinates("Unknown City") is None


pytest.main(["-v", "--tb=line", "-rN", __file__])