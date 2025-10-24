using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using SdxChannelManager.Models;

namespace SdxChannelManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private SdxDatabase? _database;
        private SdxChannel? _selectedChannel;
        private string _statusMessage;
        private bool _showTvChannels;
        private bool _showRadioChannels;
        private int _totalTvChannels;
        private int _totalRadioChannels;
        private int _totalSatellites;
        private int _totalTransponders;
        private string _fileName;
        private string _fileSize;
        private bool _showWelcome;
        private bool _showChannels;
        private string _searchText;
        private string _targetIndexText;
        private List<SdxChannel> _allCurrentTypeChannels; // Store all channels of current type (TV or Radio) for filtering

        public MainViewModel()
        {
            _statusMessage = "Ready. Open an SDX file to begin.";
            _showTvChannels = true;
            _showRadioChannels = false;
            _fileName = "No file loaded";
            _fileSize = "";
            _showWelcome = true;
            _showChannels = false;
            _searchText = string.Empty;
            _targetIndexText = string.Empty;
            _allCurrentTypeChannels = new List<SdxChannel>();

            // Initialize commands
            OpenFileCommand = new RelayCommand(_ => OpenFile());
            SaveFileCommand = new RelayCommand(_ => SaveFile(), _ => _database != null);
            SaveAsFileCommand = new RelayCommand(_ => SaveAsFile(), _ => _database != null);
            MoveUpCommand = new RelayCommand(_ => MoveUp(), _ => CanMoveUp());
            MoveDownCommand = new RelayCommand(_ => MoveDown(), _ => CanMoveDown());
            MoveToIndexCommand = new RelayCommand(_ => MoveToIndex(), _ => CanMoveToIndex());
            ShowTvCommand = new RelayCommand(_ => LoadTvChannels());
            ShowRadioCommand = new RelayCommand(_ => LoadRadioChannels());

            Channels = new ObservableCollection<SdxChannel>();
        }

        public ObservableCollection<SdxChannel> Channels { get; set; }

        public SdxChannel? SelectedChannel
        {
            get => _selectedChannel;
            set
            {
                if (_selectedChannel != value)
                {
                    _selectedChannel = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ShowTvChannels
        {
            get => _showTvChannels;
            set
            {
                if (_showTvChannels != value)
                {
                    _showTvChannels = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ShowRadioChannels
        {
            get => _showRadioChannels;
            set
            {
                if (_showRadioChannels != value)
                {
                    _showRadioChannels = value;
                    OnPropertyChanged();
                }
            }
        }

        public int TotalTvChannels
        {
            get => _totalTvChannels;
            set
            {
                if (_totalTvChannels != value)
                {
                    _totalTvChannels = value;
                    OnPropertyChanged();
                }
            }
        }

        public int TotalRadioChannels
        {
            get => _totalRadioChannels;
            set
            {
                if (_totalRadioChannels != value)
                {
                    _totalRadioChannels = value;
                    OnPropertyChanged();
                }
            }
        }

        public int TotalSatellites
        {
            get => _totalSatellites;
            set
            {
                if (_totalSatellites != value)
                {
                    _totalSatellites = value;
                    OnPropertyChanged();
                }
            }
        }

        public int TotalTransponders
        {
            get => _totalTransponders;
            set
            {
                if (_totalTransponders != value)
                {
                    _totalTransponders = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FileName
        {
            get => _fileName;
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FileSize
        {
            get => _fileSize;
            set
            {
                if (_fileSize != value)
                {
                    _fileSize = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ShowWelcome
        {
            get => _showWelcome;
            set
            {
                if (_showWelcome != value)
                {
                    _showWelcome = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ShowChannels
        {
            get => _showChannels;
            set
            {
                if (_showChannels != value)
                {
                    _showChannels = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    ApplyFilter(); // Live search - filter as user types
                }
            }
        }

        public string TargetIndexText
        {
            get => _targetIndexText;
            set
            {
                if (_targetIndexText != value)
                {
                    _targetIndexText = value;
                    OnPropertyChanged();
                    CommandManager.InvalidateRequerySuggested(); // Update button enabled state
                }
            }
        }

        public ICommand OpenFileCommand { get; }
        public ICommand SaveFileCommand { get; }
        public ICommand SaveAsFileCommand { get; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand MoveToIndexCommand { get; }
        public ICommand ShowTvCommand { get; }
        public ICommand ShowRadioCommand { get; }

        private void OpenFile()
        {
            try
            {
                var dialog = new OpenFileDialog
                {
                    Filter = "SDX Files (*.sdx)|*.sdx|All Files (*.*)|*.*",
                    Title = "Open SDX File"
                };

                if (dialog.ShowDialog() == true)
                {
                    StatusMessage = "Loading file...";
                    _database = SdxDatabase.Load(dialog.FileName);
                    
                    // Update statistics
                    UpdateStatistics();
                    
                    // Update file info
                    FileName = System.IO.Path.GetFileName(dialog.FileName);
                    var fileInfo = new System.IO.FileInfo(dialog.FileName);
                    FileSize = $"{fileInfo.Length / 1024.0 / 1024.0:F2} MB";
                    
                    // Hide welcome, show channels
                    ShowWelcome = false;
                    ShowChannels = true;
                    
                    // Show TV channels by default
                    LoadTvChannels();
                    
                    StatusMessage = $"✅ Loaded {_database.Channels.Count} channels from {System.IO.Path.GetFileName(dialog.FileName)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                StatusMessage = "❌ Error loading file.";
            }
        }
        
        private void UpdateStatistics()
        {
            if (_database == null) return;
            
            TotalTvChannels = _database.Channels.Count(c => !c.IsRadio);
            TotalRadioChannels = _database.Channels.Count(c => c.IsRadio);
            TotalSatellites = _database.SatelliteObjects.Count;
            TotalTransponders = _database.TransponderObjects.Count;
        }

        private void SaveFile()
        {
            if (_database == null) return;

            try
            {
                StatusMessage = "Saving file...";
                
                // Update the database with current channels
                UpdateDatabaseChannels();
                
                _database.Save();
                StatusMessage = $"File saved successfully to {System.IO.Path.GetFileName(_database.FilePath)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                StatusMessage = "Error saving file.";
            }
        }

        private void SaveAsFile()
        {
            if (_database == null) return;

            try
            {
                var dialog = new SaveFileDialog
                {
                    Filter = "SDX Files (*.sdx)|*.sdx|All Files (*.*)|*.*",
                    Title = "Save SDX File As",
                    FileName = System.IO.Path.GetFileName(_database.FilePath)
                };

                if (dialog.ShowDialog() == true)
                {
                    StatusMessage = "Saving file...";
                    
                    // Update the database with current channels
                    UpdateDatabaseChannels();
                    
                    _database.Save(dialog.FileName);
                    StatusMessage = $"File saved successfully to {System.IO.Path.GetFileName(dialog.FileName)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                StatusMessage = "Error saving file.";
            }
        }

        private void LoadTvChannels()
        {
            if (_database == null) return;

            // Save any changes from the current view before switching
            if (ShowRadioChannels)
            {
                UpdateDatabaseChannels();
            }

            ShowTvChannels = true;
            ShowRadioChannels = false;
            
            // Store all TV channels for filtering
            _allCurrentTypeChannels = _database.Channels.Where(c => !c.IsRadio).ToList();
            
            // Apply filter (will show all if search is empty)
            ApplyFilter();
            
            StatusMessage = $"Showing {Channels.Count} TV channels";
        }

        private void LoadRadioChannels()
        {
            if (_database == null) return;

            // Save any changes from the current view before switching
            if (ShowTvChannels)
            {
                UpdateDatabaseChannels();
            }

            ShowTvChannels = false;
            ShowRadioChannels = true;
            
            // Store all radio channels for filtering
            _allCurrentTypeChannels = _database.Channels.Where(c => c.IsRadio).ToList();
            
            // Apply filter (will show all if search is empty)
            ApplyFilter();
            
            StatusMessage = $"Showing {Channels.Count} radio channels";
        }

        private void ApplyFilter()
        {
            Channels.Clear();
            
            var filtered = _allCurrentTypeChannels.AsEnumerable();
            
            // Apply search filter if search text is not empty
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                filtered = filtered.Where(c => 
                    c.ServiceName.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
            }
            
            foreach (var channel in filtered)
            {
                Channels.Add(channel);
            }
        }

        private bool CanMoveUp()
        {
            if (SelectedChannel == null || Channels.Count < 2) return false;
            int currentIndex = Channels.IndexOf(SelectedChannel);
            return currentIndex > 0;
        }

        private bool CanMoveDown()
        {
            if (SelectedChannel == null || Channels.Count < 2) return false;
            int currentIndex = Channels.IndexOf(SelectedChannel);
            return currentIndex < Channels.Count - 1;
        }

        private void MoveUp()
        {
            if (!CanMoveUp() || SelectedChannel == null) return;

            int currentIndex = Channels.IndexOf(SelectedChannel);
            var channelToMove = SelectedChannel;
            
            // Swap positions in the observable collection
            Channels.RemoveAt(currentIndex);
            Channels.Insert(currentIndex - 1, channelToMove);
            
            // Update indices
            ReindexChannels();
            
            // Keep selection
            SelectedChannel = channelToMove;
            
            StatusMessage = $"Moved '{channelToMove.ServiceName}' up";
        }

        private void MoveDown()
        {
            if (!CanMoveDown() || SelectedChannel == null) return;

            int currentIndex = Channels.IndexOf(SelectedChannel);
            var channelToMove = SelectedChannel;
            
            // Swap positions in the observable collection
            Channels.RemoveAt(currentIndex);
            Channels.Insert(currentIndex + 1, channelToMove);
            
            // Update indices
            ReindexChannels();
            
            // Keep selection
            SelectedChannel = channelToMove;
            
            StatusMessage = $"Moved '{channelToMove.ServiceName}' down";
        }

        private void ReindexChannels()
        {
            // Don't change the index - the index is the position in the display list
            // The actual reindexing for the file will happen during save
            // This method is now a no-op but kept for future use
        }

        private bool CanMoveToIndex()
        {
            if (SelectedChannel == null || _database == null || string.IsNullOrWhiteSpace(TargetIndexText))
                return false;
            
            if (!int.TryParse(TargetIndexText, out int targetIndex))
                return false;
            
            // Validate that target index is within range
            // Use the filtered Channels collection count
            return targetIndex >= 0 && targetIndex < Channels.Count;
        }

        private void MoveToIndex()
        {
            if (_database == null || SelectedChannel == null) return;
            
            if (!int.TryParse(TargetIndexText, out int targetIndex))
            {
                MessageBox.Show("Please enter a valid number for the index.", "Invalid Input", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            try
            {
                // Call the model method to perform the move
                _database.MoveChannelToIndex(SelectedChannel, targetIndex, ShowTvChannels);
                
                // Refresh the display
                if (ShowTvChannels)
                {
                    LoadTvChannels();
                }
                else
                {
                    LoadRadioChannels();
                }
                
                // Re-select the moved channel
                SelectedChannel = Channels.FirstOrDefault(c => c == SelectedChannel);
                
                StatusMessage = $"✅ Moved '{SelectedChannel?.ServiceName}' to index {targetIndex}";
                TargetIndexText = string.Empty; // Clear the textbox
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show($"Index must be between 0 and {Channels.Count - 1}.", "Out of Range", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error moving channel: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                StatusMessage = "❌ Error moving channel";
            }
        }

        private void UpdateDatabaseChannels()
        {
            if (_database == null) return;

            // Get channels from the other category before clearing
            var unchangedChannels = _showTvChannels 
                ? _database.Channels.Where(c => c.IsRadio).ToList()
                : _database.Channels.Where(c => !c.IsRadio).ToList();
            
            // Clear and update all channels in the database
            _database.Channels.Clear();
            
            // Add the edited channels in their display order
            // The Channels collection already has the correct order from the UI
            foreach (var channel in Channels)
            {
                _database.Channels.Add(channel);
            }
            
            // Add back channels from the other category unchanged
            foreach (var channel in unchangedChannels)
            {
                _database.Channels.Add(channel);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

