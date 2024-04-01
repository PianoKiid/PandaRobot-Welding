import numpy as np
import matplotlib.pyplot as plt

def read_log_file(file_path):
    positions = {
        'LU': [],
        'RU': [],
        'LD': [],
        'RD': []
    }
    current_marker = None
    
    with open(file_path, 'r') as file:
        for line in file:
            line = line.strip()
            # Check if the line is a marker
            if line == 'LU' or line == 'RU' or line == 'LD' or line == 'RD':
                current_marker = line
            elif current_marker and line:
                # Process the data line
                parts = line.split('|')
                if len(parts) > 1:
                    pos_str = parts[1].strip()  # Assuming position data is the second part
                    if pos_str != 'null':
                        pos = [float(num) for num in pos_str.split(',')]
                        positions[current_marker].append(np.array(pos))
    
    return positions


def closest_point_on_line_segment(p, a, b):
    # p: point, a and b: ends of the line segment
    ap = p - a
    ab = b - a
    t = np.dot(ap, ab) / np.dot(ab, ab)
    t = np.clip(t, 0, 1)
    return a + t * ab

def calculate_closest_distances(positions, line_start, line_end):
    distances = []
    for position in positions:
        closest_point = closest_point_on_line_segment(position, line_start, line_end)
        distance = np.linalg.norm(position - closest_point)
        distances.append(distance)
    return distances

line_segments = {
    'LU': (np.array([-0.01, 0.95, 0.38]), np.array([-0.01, 1.23, 0.48])),
    'LD': (np.array([-0.01, 0.56, 0.38]), np.array([-0.01, 0.84, 0.38])),
    'RU': (np.array([0.01, 0.95, 0.38]), np.array([0.01, 1.23, 0.38])),
    'RD': (np.array([0.01, 0.56, 0.38]), np.array([0.01, 0.84, 0.38])),
}

# Path to your log file
# cd /mnt/c/Users/sungboo/Documents/GitHub/PandaInterface/Assets/Data/
file_path = 'log_03172211_2.txt'

# Read the log file and get the positions
positions = read_log_file(file_path)

mean_distances = []

# Calculate and store distances
for marker, (line_start, line_end) in line_segments.items():
    distances = calculate_closest_distances(positions[marker], line_start, line_end)
    mean_distance = np.mean(distances)
    mean_distances.append(mean_distance)
    print(f"Average distance for {marker}: {mean_distance}")

print(f"Total average distance: {np.mean(mean_distances)}")

# Create boxplots for the distances
fig, ax = plt.subplots()
plt.boxplot(mean_distances)
ax.set_title('Boxplot of Distances')
ax.set_ylabel('Distance')
ax.set_xlabel('Markers')

plt.show()