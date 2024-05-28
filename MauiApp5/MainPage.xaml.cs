
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Mapping;
using Map = Esri.ArcGISRuntime.Mapping.Map;


namespace MauiApp5
{
    public partial class MainPage : ContentPage
    {
        private Map? _map;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Cancellation = new CancellationTokenSource();
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            await SetupMapAsync();
        }


        public async Task SetupMapAsync() //Add all layers to the map.
        {

            CloseMap();
            if (MapOpen) return;
            try
            {
                var asd = AppDomain.CurrentDomain.BaseDirectory;
                var as2 = Path.Combine(asd, "..\\..\\..\\..\\..\\Tiles");

                // LOAD BASEMAP
                Map combinedMap = new();

                var baseMaps = Directory.GetFiles(as2);
                if (!baseMaps.Any())
                {
                    return;
                }
                foreach (string vectorTileUri in baseMaps)
                {
                    Uri vtpkFile = new(vectorTileUri);
                    ArcGISVectorTiledLayer basemapTileCacheItem = new(vtpkFile);

                    combinedMap.Basemap!.BaseLayers.Add(basemapTileCacheItem);
                }

                Map = combinedMap;
                ShowMapDialog = false;
                MapOpen = true;
            }
            catch (Exception ex)
            {
                MapOpen = false;
            }
        }

        /// <summary>
        ///     The map object.  It is important to note that the SS Map layers and data use a custom projection, always reference the WKID 4269 (GCS: NAD 1983)
        /// </summary>
        public Map? Map
        {
            get => _map;
            set
            {
                _map = value;
                OnPropertyChanged();
            }
        }

        public void CloseMap()
        {

            try
            {
                Map?.CancelLoad();
                Map = null;
                MapOpen = false;
            }
            catch (Exception e)
            {
                // _logger.LogError(e, "Error closing map when trying to sync new version.");
            }

        }

        public bool ShowMapDialog { get; set; }

        public bool MapOpen { get; set; }
        public CancellationTokenSource Cancellation { get; set; }
    }
}
